using Ametista.Core;
using System.Threading.Tasks;

namespace Ametista.Query
{
    public interface IMaterializerDispatcher
    {
        Task<bool> Dispatch<TEvent>(IMaterializer<TEvent> e) where TEvent : IEvent;
    }
}