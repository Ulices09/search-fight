using SearchFight.Presenter.Interfaces;
using SearchFight.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchFight.Presenter
{
    public class SearchFightPresenter : ISearchFightPresenter
    {
        private readonly ISearchFightService searchFightService;

        public SearchFightPresenter(ISearchFightService searchFightService)
        {
            this.searchFightService = searchFightService;
        }

        public void SearchFight(string[] programmingLanguages)
        {
            if (programmingLanguages.Length == 0)
            {
                Console.WriteLine("You must provide programming languages to search");
                return;
            }

            var result = searchFightService.SearchFight(programmingLanguages);

            foreach (var item in result.ProgrammingLanguageResults)
            {
                Console.WriteLine(item.ProgrammingLanguage + ":");
                Console.WriteLine("    Google: " + item.GoogleTotal + " Bing: " + item.BingTotal);
            }

            Console.WriteLine();
            Console.WriteLine("Google Winner: " + result.GoogleWinner);
            Console.WriteLine("Bing Winner: " + result.BingWinner);
        }
    }
}
