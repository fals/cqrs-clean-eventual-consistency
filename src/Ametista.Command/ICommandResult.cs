using System;

namespace Ametista.Command
{
    public interface ICommandResult
    {
        bool Success { get; }
        DateTime Executed { get; }
    }
}