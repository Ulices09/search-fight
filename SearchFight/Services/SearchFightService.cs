using SearchFight.Core.Models;
using SearchFight.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchFight.Services
{
    public class SearchFightService : ISearchFightService
    {
        private readonly ISearchService searchService;

        public SearchFightService(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        public SearchFightResult SearchFight(string[] programmingLanguages)
        {
            string googleWinner = "";
            int googleTotal = 0;
            string bingWinner = "";
            int bingTotal = 0;

            var results = new List<ProgrammingLanguageResult>();

            foreach (var language in programmingLanguages)
            { 
                var result = searchService.SearchProgrammingLanguageResults(language);

                if (result.GoogleTotal > googleTotal)
                {
                    googleWinner = result.ProgrammingLanguage;
                    googleTotal = result.GoogleTotal;
                }

                if (result.BingTotal > bingTotal)
                {
                    bingWinner = result.ProgrammingLanguage;
                    bingTotal = result.BingTotal;
                }

                results.Add(result);
            }

            return new SearchFightResult
            {
                ProgrammingLanguageResults = results,
                BingWinner = bingWinner,
                GoogleWinner = googleWinner
            };
        }
    }
}
