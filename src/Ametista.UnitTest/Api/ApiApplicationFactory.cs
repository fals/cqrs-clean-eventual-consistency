using Ametista.Core.Interfaces;
using Ametista.Infrastructure.Persistence;
using Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Ametista.UnitTest.Api
{
    public class ApiApplicationFactory : WebApplicationFactory<Ametista.Api.Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<WriteDbContext>));

                services.Remove(descriptor);

                var _connection = new SqliteConnection("datasource=:memory:");
                _connection.Open();

                services.AddDbContext<WriteDbContext>(options =>
                {
                    options.UseSqlite(_connection);
                });

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<WriteDbContext>();
                    var logger = scopedServices
                        .GetRequiredService<ILogger<ApiApplicationFactory>>();

                    db.Database.EnsureCreated();
                }
            }).ConfigureTestContainer<ContainerBuilder>(builder =>
            {
                builder
                   .RegisterType<Fakes.FakeCache>()
                   .As<ICache>()
                   .SingleInstance();

                builder
                    .RegisterType<Fakes.FakeEventBus>()
                    .As<IEventBus>()
                    .SingleInstance();
            });
        }
    }
}
