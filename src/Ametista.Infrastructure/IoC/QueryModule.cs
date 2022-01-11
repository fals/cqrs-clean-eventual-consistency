using Ametista.Query;
using Ametista.Query.Abstractions;
using Ametista.Query.Materializers;
using Autofac;
using System.Reflection;

namespace Ametista.Infrastructure.IoC
{
    public class QueryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IQueryHandler<,>).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IQueryHandler<,>))
                .InstancePerLifetimeScope();

            builder
                .RegisterType<ReadDbContext>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<QueryDispatcher>()
                .As<IQueryDispatcher>()
                .SingleInstance();

            builder
                .RegisterType<CardListQueryModelMaterializer>()
                .As<ICardListQueryModelMaterializer>()
                .SingleInstance();

            builder
                .RegisterType<TransactionListQueryModelMaterializer>()
                .As<ITransactionListQueryModelMaterializer>()
                .SingleInstance();
        }
    }
}