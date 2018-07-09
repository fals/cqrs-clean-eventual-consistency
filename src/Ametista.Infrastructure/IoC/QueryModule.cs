using Ametista.Core;
using Autofac;
using System.Reflection;

namespace Ametista.Infrastructure
{
    public class QueryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IQueryHandler<,>).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IQueryHandler<,>))
                .InstancePerLifetimeScope();

            builder
                .RegisterType<QueryDispatcher>()
                .As<IQueryDispatcher>();
        }
    }
}
