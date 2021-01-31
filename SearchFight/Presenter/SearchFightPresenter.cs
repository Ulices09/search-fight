using SearchFight.Core.Models;
using SearchFight.Presenter.Interfaces;
using SearchFight.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Presenter
{
    public class SearchFightPresenter : ISearchFightPresenter
    {
        private readonly ISearchFightService searchFightService;

        public SearchFightPresenter(ISearchFightService searchFightService)
        {
            this.searchFightService = searchFightService;
        }

        public async Task SearchFight(string[] programmingLanguages)
        {
            if (programmingLanguages.Length == 0)
            {
                Console.WriteLine("You must provide programming languages to search");
                return;
            }

            try
            {
                var result = await searchFightService.SearchFight(programmingLanguages);

                foreach (var item in result.ProgrammingLanguageResults)
                {
                    Console.WriteLine(item.ProgrammingLanguage + ":");
                    Console.WriteLine("    Google: " + item.GoogleTotal + " Bing: " + item.BingTotal);
                }

                Console.WriteLine();
                Console.WriteLine("Google Winner: " + result.GoogleWinner);
                Console.WriteLine("Bing Winner: " + result.BingWinner);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong: " + ex.Message);
            }

            
        }
    }
}
