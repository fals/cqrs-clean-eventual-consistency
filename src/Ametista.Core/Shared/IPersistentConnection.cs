using System;

namespace Ametista.Core.Interfaces
{
    public interface IPersistentConnection<T> : IDisposable
    {
        bool IsConnected { get; }

        bool TryConnect();

        T CreateModel();
    }
}
