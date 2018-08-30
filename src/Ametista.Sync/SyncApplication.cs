using Ametista.Core.Events;
using Ametista.Core.Interfaces;

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
            eventBus.Subscribe<CardCreatedEvent>();
            eventBus.Subscribe<TransactionCreatedEvent>();
        }
    }
}