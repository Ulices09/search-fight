using Microsoft.Extensions.DependencyInjection;
using SearchFight.HttpClients;
using SearchFight.HttpClients.Interfaces;
using SearchFight.Presenter;
using SearchFight.Presenter.Interfaces;
using SearchFight.Services;
using SearchFight.Services.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SearchFight
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = BuildServiceProvider();

            var searchFightPresenter = serviceProvider.GetService<ISearchFightPresenter>();
            await searchFightPresenter.SearchFight(args);
        }

        private static ServiceProvider BuildServiceProvider()
        {
            return new ServiceCollection()
                .AddScoped<ISearchFightPresenter, SearchFightPresenter>()
                .AddScoped<ISearchFightService, SearchFightService>()
                .AddScoped<ISearchService, SearchService>()
                .AddScoped<ISearchHttpClient, SearchHttpClient>()
                .AddScoped<HttpClient>()
                .BuildServiceProvider();
        }
    }
}
