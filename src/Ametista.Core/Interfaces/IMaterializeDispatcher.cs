using Ametista.Core.Interfaces;
using System.Threading.Tasks;

namespace Ametista.Core
{
    public interface IMaterializerDispatcher
    {
        Task<bool> Dispatch<TEvent>(IMaterializer<TEvent> e) where TEvent : IEvent;
    }
}
