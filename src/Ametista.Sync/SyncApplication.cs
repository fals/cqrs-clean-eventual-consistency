using Ametista.Core.Transactions;
using Ametista.Core.Cards;
using Ametista.Core.Interfaces;
using System;
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
            Console.WriteLine("Start Sync Application!");
            Console.WriteLine("Waiting for messages");

            while (true)
            {
                eventBus.Subscribe<CardCreatedEvent>();
                eventBus.Subscribe<TransactionCreatedEvent>();

                Task.Delay(1000);
            }
        }
    }
}