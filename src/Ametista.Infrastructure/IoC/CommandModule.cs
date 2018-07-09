using Ametista.Core;
using Autofac;
using System.Reflection;

namespace Ametista.Infrastructure
{
    public class CommandModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(typeof(ICommandHandler<,>).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(ICommandHandler<,>))
                .InstancePerLifetimeScope();
            builder
                .RegisterAssemblyTypes(typeof(ICommandHandler<>).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(ICommandHandler<>))
                .InstancePerLifetimeScope();

            builder
                .RegisterType<CommandDispatcher>()
                .As<ICommandDispatcher>();
        }
    }
}
