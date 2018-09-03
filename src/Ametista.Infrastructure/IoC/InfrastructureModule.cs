using Ametista.Core.Interfaces;
using Ametista.Core.Repository;
using Ametista.Infrastructure.Bus;
using Ametista.Infrastructure.Persistence.Repository;
using Autofac;

namespace Ametista.Infrastructure.IoC
{
    public class InfrastructureModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<CardRepository>()
                .As<ICardRepository>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<TransactionRepository>()
                .As<ITransactionRepository>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<RabbitMQEventBus>()
                .As<IEventBus>()
                .SingleInstance();
        }
    }
}