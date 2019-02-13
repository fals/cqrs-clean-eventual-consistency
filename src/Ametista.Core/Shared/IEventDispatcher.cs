using System.Threading.Tasks;

namespace Ametista.Core.Interfaces
{
    public interface IEventDispatcher
    {
        Task Dispatch<TEvent>(TEvent e) where TEvent : IEvent;
    }
}