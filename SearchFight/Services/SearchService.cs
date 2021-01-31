using SearchFight.Core.Models;
using SearchFight.HttpClients.Interfaces;
using SearchFight.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Services
{
    public class SearchService : ISearchService
    {
        private readonly ISearchHttpClient searchHttpClient;
        
        public SearchService(ISearchHttpClient searchHttpClient)
        {
            this.searchHttpClient = searchHttpClient;
        }

        public async Task<ProgrammingLanguageResult> SearchProgrammingLanguageResults(string programmingLanguage)
        {
            int bingTotal = await searchHttpClient
                .GetBingResults(programmingLanguage);

            int googleTotal = await searchHttpClient.
                GetGoogleResults(programmingLanguage);

            return new ProgrammingLanguageResult
            {
                ProgrammingLanguage = programmingLanguage,
                BingTotal = bingTotal,
                GoogleTotal = googleTotal,
            };
        }
    }
}
