using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SearchFight.Core.Models;
using SearchFight.HttpClients;
using SearchFight.HttpClients.Interfaces;
using SearchFight.Presenter;
using SearchFight.Presenter.Interfaces;
using SearchFight.Services;
using SearchFight.Services.Interfaces;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace SearchFight
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);
            var configRoot = builder.Build();

            var configuration = new Configuration();
            configRoot.Bind(configuration);

            var serviceProvider = BuildServiceProvider(configuration);

            var searchFightPresenter = serviceProvider.GetService<ISearchFightPresenter>();
            await searchFightPresenter.SearchFight(args);
        }

        private static ServiceProvider BuildServiceProvider(Configuration configuration)
        {
            return new ServiceCollection()
                .AddScoped<ISearchFightPresenter, SearchFightPresenter>()
                .AddScoped<ISearchFightService, SearchFightService>()
                .AddScoped<ISearchService, SearchService>()
                .AddScoped<ISearchHttpClient, SearchHttpClient>()
                .AddScoped<HttpClient>()
                .AddSingleton(configuration)
                .BuildServiceProvider();
        }

        private static void BuildConfig(IConfigurationBuilder builder)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env}.json", true, true)
                .AddEnvironmentVariables();
        }
    }
}
