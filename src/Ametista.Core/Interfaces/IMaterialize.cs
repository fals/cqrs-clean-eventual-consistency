using System.Threading.Tasks;

namespace Ametista.Core.Interfaces
{
    public interface IMaterialize<TEvent> where TEvent : IEvent
    {
        Task<bool> Materialize(TEvent e);
    }
}
