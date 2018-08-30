using Ametista.Infrastructure.IoC;
using Ametista.Sync;
using Autofac;
using System;

namespace Amestista.Sync
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Start Sync Application!");

            var builder = new ContainerBuilder();
            builder.RegisterType<SyncApplication>()
                .As<IApplication>();

            builder.RegisterModule(new CommandModule());
            builder.RegisterModule(new EventModule());
            builder.RegisterModule(new MaterializeModule());
            builder.RegisterModule(new InfrastructureModule());
            builder.RegisterModule(new QueryModule());

            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                app.Run();
            }

            Console.WriteLine("Started Sync Application!");
            Console.WriteLine("Waiting for messages");
            Console.Read();
        }
    }
}