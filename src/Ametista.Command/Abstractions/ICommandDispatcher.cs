using System.Threading.Tasks;

namespace Ametista.Command.Abstractions
{
    public interface ICommandDispatcher
    {
        Task<TResult> Dispatch<TResult>(ICommand<TResult> command) where TResult : ICommandResult;

        Task DispatchNonResult(ICommand command);
    }
}