using Ametista.Core;
using Ametista.Infrastructure.IoC;
using Ametista.Infrastructure.Persistence;
using Ametista.Sync;
using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace Amestista.Sync
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            IConfigurationRoot configuration = configBuilder.Build();

            var builder = new ContainerBuilder();
            builder.RegisterType<SyncApplication>()
                .As<IApplication>();

            builder.RegisterType<LoggerFactory>()
                .As<ILoggerFactory>()
                .SingleInstance();

            builder
                .RegisterGeneric(typeof(Logger<>))
                .As(typeof(ILogger<>))
                .SingleInstance();
            
            builder.RegisterModule(new InfrastructureModule());
            builder.RegisterModule(new EventModule());
            builder.RegisterInstance(configuration.Get<AmetistaConfiguration>());

            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                app.Run();
            }
        }
    }
}