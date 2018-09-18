using Ametista.Core.Interfaces;
using Ametista.Core.Repository;
using Ametista.Infrastructure.Bus;
using Ametista.Infrastructure.Persistence.Repository;
using Autofac;
using RabbitMQ.Client;

namespace Ametista.Infrastructure.IoC
{
    public class InfrastructureModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<CardWriteOnlyRepository>()
                .As<ICardWriteOnlyRepository>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<TransactionWriteOnlyRepository>()
                .As<ITransactionWriteOnlyRepository>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<RabbitMQPersistentConnection>()
                .As<IPersistentConnection<IModel>>()
                .SingleInstance();

            builder
                .RegisterType<RabbitMQEventBus>()
                .As<IEventBus>()
                .SingleInstance();
        }
    }
}