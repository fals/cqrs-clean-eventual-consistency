using Ametista.Core.Interfaces;
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
                .RegisterType<EventDispatcher>()
                .As<IEventDispatcher>();
        }
    }
}