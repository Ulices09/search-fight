using SearchFight.Core.Models;
using SearchFight.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchFight.Services
{
    public class SearchService : ISearchService
    {
        public SearchService()
        {

        }

        public ProgrammingLanguageResult SearchProgrammingLanguageResults(string programmingLanguage)
        {
            Random random = new Random();
            int randomBing = random.Next(0, 10000000);
            int randomGoogle = random.Next(0, 10000000);

            return new ProgrammingLanguageResult
            {
                ProgrammingLanguage = programmingLanguage,
                BingTotal = randomBing,
                GoogleTotal = randomGoogle,
            };
        }
    }
}
