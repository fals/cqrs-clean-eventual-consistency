using System;
using System.Collections.Generic;
using System.Text;

namespace Ametista.Core
{
    public interface ICommandResult
    {
        bool Succss { get; }
        DateTime Executed { get; }
    }
}
