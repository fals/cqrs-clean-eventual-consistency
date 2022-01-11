using System;

namespace Ametista.Command.Abstractions
{
    public abstract class CommandResult : ICommandResult
    {
        protected CommandResult()
        {
            Success = false;
            Executed = DateTime.Now;
        }
        protected CommandResult(bool success)
        {
            Success = success;
            Executed = DateTime.Now;
        }

        public bool Success { get; set; }

        public DateTime Executed { get; set; }

        public static TCommandResul CreateFailResult<TCommandResul>() where TCommandResul : CommandResult, new()
        {
            return new TCommandResul();
        }
    }
}