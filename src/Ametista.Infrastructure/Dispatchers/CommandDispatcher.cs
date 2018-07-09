using Ametista.Core;
using Autofac;
using System.Threading.Tasks;

namespace Ametista.Infrastructure
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext componentContext;

        public CommandDispatcher(IComponentContext componentContext)
        {
            this.componentContext = componentContext;
        }

        public Task<TResult> Dispatch<TResult>(ICommand<TResult> command) where TResult : ICommandResult
        {
            if (command == null)
            {
                throw new System.ArgumentNullException(nameof(command));
            }

            var commandHandlerType = typeof(ICommandHandler<,>).MakeGenericType(command.GetType(), typeof(TResult));

            dynamic handler = componentContext.Resolve(commandHandlerType);

            return (Task<TResult>)commandHandlerType
                .GetMethod("Handle")
                .Invoke(handler, new object[] { command });

        }
        public Task DispatchNonResult(ICommand command)
        {
            var commandHandlerType = typeof(ICommandHandler<>).MakeGenericType(command.GetType());

            dynamic handler = componentContext.Resolve(commandHandlerType);

            return (Task)commandHandlerType
                .GetMethod("HandleNonResult")
                .Invoke(handler, new object[] { command });

        }
    }
}
