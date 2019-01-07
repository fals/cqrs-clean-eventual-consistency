using Ametista.Core.Interfaces;
using Ametista.Infrastructure.Bus;
using Ametista.Infrastructure.Cache;
using Autofac;
using RabbitMQ.Client;

namespace Ametista.Infrastructure.IoC
{
    public class InfrastructureModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<RabbitMQPersistentConnection>()
                .As<IPersistentConnection<IModel>>()
                .SingleInstance();

            builder
                .RegisterType<RedisCache>()
                .As<ICache>()
                .SingleInstance();

            builder
                .RegisterType<RabbitMQEventBus>()
                .As<IEventBus>()
                .SingleInstance();
        }
    }
}