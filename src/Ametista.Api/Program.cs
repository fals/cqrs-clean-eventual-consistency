using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Autofac.Extensions.DependencyInjection;

namespace Ametista.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .ConfigureServices(services => services.AddAutofac())
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .Build();
    }
}