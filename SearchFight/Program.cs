using Microsoft.Extensions.DependencyInjection;
using SearchFight.Presenter;
using SearchFight.Presenter.Interfaces;
using SearchFight.Services;
using SearchFight.Services.Interfaces;
using System;

namespace SearchFight
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = BuildServiceProvider();

            var searchFightPresenter = serviceProvider.GetService<ISearchFightPresenter>();
            searchFightPresenter.SearchFight(args);
        }

        private static ServiceProvider BuildServiceProvider()
        {
            return new ServiceCollection()
                .AddScoped<ISearchFightPresenter, SearchFightPresenter>()
                .AddScoped<ISearchFightService, SearchFightService>()
                .AddScoped<ISearchService, SearchService>()
                .BuildServiceProvider();
        }
    }
}
