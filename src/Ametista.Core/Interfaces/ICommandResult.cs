using System;
using System.Collections.Generic;
using System.Text;

namespace Ametista.Core
{
    public interface ICommandResult
    {
        bool Success { get; }
        DateTime Executed { get; }
    }
}
