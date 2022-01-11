using Ametista.Command.Abstractions;
using Ametista.Core.Cards;
using Ametista.Core.Transactions;
using Ametista.Infrastructure.Persistence.Repository;
using Autofac;
using System.Reflection;

namespace Ametista.Infrastructure.IoC
{
    public class CommandModule : Autofac.Module
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
                .RegisterAssemblyTypes(typeof(ICommandHandler<,>).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(ICommandHandler<,>))
                .InstancePerLifetimeScope();

            builder
                .RegisterAssemblyTypes(typeof(ICommandHandler<>).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(ICommandHandler<>))
                .InstancePerLifetimeScope();

            builder
                .RegisterType<CommandDispatcher>()
                .As<ICommandDispatcher>()
                .SingleInstance();
        }
    }
}