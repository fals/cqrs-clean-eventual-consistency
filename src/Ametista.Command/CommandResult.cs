using Ametista.Core;
using System;

namespace Ametista.Application
{
    public abstract class CommandResult : ICommandResult
    {
        protected CommandResult()
        {
            Executed = DateTime.Now;
        }

        public bool Success { get; set; }

        public DateTime Executed { get; set; }
    }
}
