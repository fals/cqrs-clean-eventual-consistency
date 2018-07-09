namespace Ametista.Core
{
    public interface ICommand
    { }

    public interface ICommand<TResult> : ICommand where TResult : ICommandResult
    { }
}
