
using SCGPS.Domain.Commands;
using SCGPS.Domain.Results;

namespace SCGPS.Logic
{
    public interface IExecuter
    {
        Task<TResult> ExecuteAsync<TResult, TCommand>(TCommand command, Type type, Func<TCommand, Task<TResult>> func, bool withoutTransaction = false)
            where TResult : ServiceResult, new()
            where TCommand : ServiceCommand;
    }
}
