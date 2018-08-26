using Ametista.Core;
using Ametista.Query;
using Autofac;
using System.Reflection;

namespace Ametista.Infrastructure.IoC
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
                .RegisterType<MaterializerDispatcher>()
                .As<IMaterializerDispatcher>();
        }
    }
}
