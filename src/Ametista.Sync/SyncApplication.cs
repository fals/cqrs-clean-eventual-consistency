using Ametista.Core.Events;
using Ametista.Core.Interfaces;
using System.Threading.Tasks;

namespace Ametista.Sync
{
    public interface IApplication
    {
        void Run();
    }

    public class SyncApplication : IApplication
    {
        private readonly IEventBus eventBus;

        public SyncApplication(IEventBus eventBus)
        {
            this.eventBus = eventBus;
        }

        public void Run()
        {
            Task.Run(() => eventBus.Subscribe<CardCreatedEvent>());
            Task.Run(() => eventBus.Subscribe<TransactionCreatedEvent>());
            //eventBus.Subscribe<TransactionCreatedEvent>();
        }
    }
}