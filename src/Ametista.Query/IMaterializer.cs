using Ametista.Core;
using System.Threading.Tasks;

namespace Ametista.Query
{
    public interface IMaterializer<TEvent> where TEvent : IEvent
    {
        Task<bool> Materialize(TEvent e);
    }
}