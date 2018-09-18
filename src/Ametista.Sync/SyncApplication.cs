using Ametista.Core.Events;
using Ametista.Core.Interfaces;
using System;

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

            eventBus.Subscribe<CardCreatedEvent>();
            eventBus.Subscribe<TransactionCreatedEvent>();

            Console.WriteLine("Started Sync Application!");
            Console.WriteLine("Waiting for messages");
            Console.Read();
        }
    }
}