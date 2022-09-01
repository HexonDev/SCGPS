using SCGPS.Data;
using SCGPS.Data.Entities;
using SCGPS.Domain.Commands;
using SCGPS.Domain.Commands.Entity;
using SCGPS.Domain.Enums;
using SCGPS.Domain.Exceptions;
using SCGPS.Domain.Results.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCGPS.Logic.Services.Entity
{
    public class EntityService<T> : IEntityService<T> where T : BaseEntity
    {
        private readonly IExecuter executer;
        private readonly IAppDbContext context;

        public EntityService(IExecuter executer, IAppDbContext context)
        {
            this.executer = executer ?? throw new ArgumentNullException(nameof(executer));
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<EntityResult<T>> AddOrModifyAsync(EntityCommand<T> command)
        {
            return await executer.ExecuteAsync(command, this.GetType(), async param =>
            {
                if (param.Entity.Id > 0)
                {
                    var entity = context.Set<T>().Find(param.Entity.Id);

                    if (entity == null)
                    {
                        throw new ScGpsException(ErrorCodes.ServiceGeneralEntityNotFound);
                    }

                    var entry = context.Entry(entity);
                    entry.CurrentValues.SetValues(context.Entry(param.Entity).CurrentValues);

                    await context.SaveChangesAsync();

                    return new EntityResult<T> { Entity = entity };
                }
                else
                {
                    var entry = await context.Set<T>().AddAsync(param.Entity);
                    await context.SaveChangesAsync();

                    return new EntityResult<T> { Entity = entry.Entity };
                }
            });
        }

        public async Task<EntityResult<T>> DeleteAsync(EntityCommand<T> command)
        {
            return await executer.ExecuteAsync(command, this.GetType(), async param =>
            {
                if (param.Entity.Id > 0)
                {
                    var entity = await context.Set<T>().FindAsync(param.Entity.Id);

                    if (entity == null)
                    {
                        throw new ScGpsException(ErrorCodes.ServiceGeneralEntityNotFound);
                    }

                    var entry = context.Set<T>().Remove(entity);

                    return new EntityResult<T>(entry.Entity);
                }
                else
                {
                    throw new ScGpsException(ErrorCodes.ServiceGeneralNoId);
                }
            });
        }

        public async Task<EntityResult<T>> GetByIdAsync(IdCommand command)
        {
            return await executer.ExecuteAsync(command, this.GetType(), async param =>
            {                
                var entity = await context.Set<T>().FindAsync(param.Id);

                if (entity == null)
                {
                    throw new ScGpsException(ErrorCodes.ServiceGeneralEntityNotFound);
                }

                return new EntityResult<T>(entity);
            });
        }
    }
}
