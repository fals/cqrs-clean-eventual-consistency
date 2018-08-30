using System.Threading.Tasks;

namespace Ametista.Core.Interfaces
{
    public interface IEventDispatcher
    {
        Task<bool> Dispatch<TEvent>(TEvent e) where TEvent : IEvent;
    }
}