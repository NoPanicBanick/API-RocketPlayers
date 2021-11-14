using API.Player;
using API.Player.AutoMapper;
using API.Player.v1.Services;
using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using DataAccess.Player.v1;
using DataAccess.Player.v1.DataEntities;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PoorMan;
using System;

[assembly: FunctionsStartup(typeof(Startup))]
namespace API.Player
{
    public class Startup : FunctionsStartup
    {
        /// <summary>
        /// Setup Configuration
        /// </summary>
        /// <param name="builder"></param>
        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            builder.ConfigurationBuilder
               .SetBasePath(Environment.CurrentDirectory)
               .AddEnvironmentVariables();
            var configReader = builder.ConfigurationBuilder.Build();
            var kvClient = new SecretClient(new Uri(configReader["keyvaulturl"]), new DefaultAzureCredential());
            builder.ConfigurationBuilder.AddAzureKeyVault(kvClient, new KeyVaultSecretManager())
                .AddJsonFile("local.settings.json", false);
        }

        /// <summary>
        /// Configure Services Container
        /// </summary>
        /// <param name="builder"></param>
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var config = builder.GetContext().Configuration;
            var mapperConfig = new AutoMapperConfiguration(new MapperProfile());
            builder.Services
                .AddScoped<ITable<PlayerTableEntity>>((services) => new AzureTable<PlayerTableEntity>(
                    new Uri(config["tableStorageUri"]), 
                    config["storageAccountName"], 
                    config["rocketplayers:storage:key"]
                    )
                )
                .AddScoped<IPlayerRepository, PlayerRepository>()
                .AddScoped<IPlayerService, PlayerService>()
                .AddSingleton(mapperConfig.GetMapper()); // IMapper

        }
    }
}
