using Ametista.Core.Events;
using Ametista.Core.Interfaces;
using Ametista.Query.EventHandlers;
using Autofac;
using System.Reflection;

namespace Ametista.Infrastructure.IoC
{
    public class EventModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(typeof(IEventHandler<>).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IEventHandler<>))
                .InstancePerLifetimeScope();

            builder
                .RegisterType<MaterializeCardEventHandler>()
                .As<IEventHandler<CardCreatedEvent>>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<MaterializeTransactionEventHandler>()
                .As<IEventHandler<TransactionCreatedEvent>>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<EventDispatcher>()
                .As<IEventDispatcher>()
                .SingleInstance();
        }
    }
}