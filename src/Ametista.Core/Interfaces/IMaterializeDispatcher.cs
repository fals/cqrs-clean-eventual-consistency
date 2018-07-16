using Ametista.Core.Interfaces;
using System.Threading.Tasks;

namespace Ametista.Core
{
    public interface IMaterializeDispatcher
    {
        Task<bool> Dispatch<TEvent>(IMaterialize<TEvent> e) where TEvent : IEvent;
    }
}
