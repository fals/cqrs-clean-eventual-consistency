namespace Ametista.Command.Abstractions
{
    public interface ICommand
    { }

    public interface ICommand<TResult> : ICommand where TResult : ICommandResult
    { }
}