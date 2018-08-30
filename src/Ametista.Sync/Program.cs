using Ametista.Core;
using Ametista.Infrastructure.IoC;
using Ametista.Sync;
using Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.IO;

namespace Amestista.Sync
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Start Sync Application!");

            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            IConfigurationRoot configuration = configBuilder.Build();

            var builder = new ContainerBuilder();
            builder.RegisterType<SyncApplication>()
                .As<IApplication>();

            builder.RegisterModule(new CommandModule());
            builder.RegisterModule(new EventModule());
            builder.RegisterModule(new InfrastructureModule());
            builder.RegisterModule(new QueryModule());
            builder.RegisterInstance(configuration.Get<AmetistaConfiguration>());

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