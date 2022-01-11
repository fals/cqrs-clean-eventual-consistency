using System;

namespace Ametista.Command.Abstractions
{
    public interface ICommandResult
    {
        bool Success { get; }
        DateTime Executed { get; }
    }
}