using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SCGPS.Data;
using SCGPS.Domain;
using SCGPS.Domain.Commands;
using SCGPS.Domain.Exceptions;
using SCGPS.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCGPS.Logic
{
    public class Executer : IExecuter
    {
        private readonly IAppDbContext context;
        private readonly IServiceProvider services;

        public Executer(IAppDbContext context, IServiceProvider services)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.services = services ?? throw new ArgumentNullException(nameof(services));
        }

        private int level = 0;

        public async Task<TResult> ExecuteAsync<TResult, TCommand>(TCommand command, Type type, Func<TCommand, Task<TResult>> func, bool withoutTransaction = false)
            where TResult : ServiceResult, new()
            where TCommand : ServiceCommand
        {

            level++;

            TResult result = new TResult();
            var transaction = context.Database.CurrentTransaction ?? await context.Database.BeginTransactionAsync();

            try
            {
                await ValidateAsync(command);

                result = await func(command);

                if(context.Database.CurrentTransaction != null && level == 1)
                {
                    await context.Database.CurrentTransaction.CommitAsync();
                }

                result.IsSucceded = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex.GetException();
                result.IsSucceded = false;

                if(context.Database.CurrentTransaction != null && level == 1)
                {
                    transaction.Rollback();
                }
            }
            finally
            {
                level--;
            }

            return result;
        }

        private async Task ValidateAsync<TCommand>(TCommand command) where TCommand : IServiceCommand
        {
            var validator = services.GetService<AbstractValidator<TCommand>>();

            if (validator != null)
            {
                var validationResult = await validator.ValidateAsync(command);

                if (!validationResult.IsValid)
                {
                    var validationErrors = new List<ValidationError>();
                    validationResult.Errors.ForEach(error => validationErrors.Add(new ValidationError(error.PropertyName, error.ErrorMessage)));

                    throw new ScGpsValidationException(validationErrors);
                }
            }
            else
            {
                if (command is not EmptyCommand)
                {
                    throw new InvalidOperationException($"Nem található validátor: {command.GetType().Name}");
                }
            }
        }

    }
}
