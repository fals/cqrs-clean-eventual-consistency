using Ametista.Core.Interfaces;
using System.Threading.Tasks;

namespace Ametista.Core
{
    public interface IMaterializeDispatcher
    {
        Task<bool> Dispatch<TEvent>(IMaterializer<TEvent> e) where TEvent : IEvent;
    }
}
