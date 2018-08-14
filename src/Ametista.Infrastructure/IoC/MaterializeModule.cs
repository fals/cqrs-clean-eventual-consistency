using Ametista.Core;
using Autofac;
using System.Reflection;

namespace Ametista.Infrastructure
{
    public class MaterializeModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(typeof(IMaterializer<>).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IMaterializer<>))
                .InstancePerLifetimeScope();

            builder
                .RegisterType<CommandDispatcher>()
                .As<IMaterializerDispatcher>();
        }
    }
}
