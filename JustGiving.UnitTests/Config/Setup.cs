using JG.FinTechTest.Shared.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace JG.FinTechTest.UnitTests.Config
{
    public class Setup
    {
        public ServiceProvider ServiceProvider { get; private set; }

        public Setup()
        {
            var serviceCollection = new ServiceCollection();
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(
                     path: "appsettings.json",
                     optional: false,
                     reloadOnChange: true)
               .Build();

            serviceCollection.AddSingleton<IConfiguration>(configuration);
            serviceCollection.Configure<GiftAidSetup>(configuration.GetSection("GiftAidSetup"));

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}