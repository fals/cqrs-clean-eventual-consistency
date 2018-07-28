using System.Threading.Tasks;

namespace Ametista.Core
{
    public interface IMaterializer<TEvent> where TEvent : IEvent
    {
        Task<bool> Materialize(TEvent e);
    }
}
