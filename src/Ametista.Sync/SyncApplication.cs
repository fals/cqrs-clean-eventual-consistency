using Ametista.Core.Events;
using Ametista.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
            eventBus.Subscribe<NewCardCreatedEvent>();
        }
    }
}
