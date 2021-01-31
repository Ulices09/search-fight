using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SearchFight.HttpClients.Interfaces;
using SearchFight.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Test.Services
{
    [TestClass]
    public class SearchFightServiceTests
    {
        [TestMethod]
        public async Task SearchFight()
        {
            string cSharp = "C#";
            int cSharpGoogleTotal = 20000;
            int cSharpBingTotal = 50000;

            string js = "JavaScript";
            int jsGoogleTotal = 30000;
            int jsBingTotal = 40000;

            var programmingLanguages = new string[]
            {
                cSharp,
                js
            };

            var searchHttpClient = new Mock<ISearchHttpClient>();
            searchHttpClient
                .Setup(x => x.GetGoogleResults(cSharp))
                .Returns(Task.FromResult(cSharpGoogleTotal));
            searchHttpClient
                .Setup(x => x.GetBingResults(cSharp))
                .Returns(Task.FromResult(cSharpBingTotal));

            searchHttpClient
               .Setup(x => x.GetGoogleResults(js))
               .Returns(Task.FromResult(jsGoogleTotal));
            searchHttpClient
                .Setup(x => x.GetBingResults(js))
                .Returns(Task.FromResult(jsBingTotal));

            var searchService = new SearchService(searchHttpClient.Object);
            var searchFightService = new SearchFightService(searchService);

            var result = await searchFightService.SearchFight(programmingLanguages);
            var cSharpResult = result.ProgrammingLanguageResults[0];
            var jsResult = result.ProgrammingLanguageResults[1];

            Assert.AreEqual(cSharp, cSharpResult.ProgrammingLanguage);
            Assert.AreEqual(cSharpGoogleTotal, cSharpResult.GoogleTotal);
            Assert.AreEqual(cSharpBingTotal, cSharpResult.BingTotal);

            Assert.AreEqual(js, jsResult.ProgrammingLanguage);
            Assert.AreEqual(jsGoogleTotal, jsResult.GoogleTotal);
            Assert.AreEqual(jsBingTotal, jsResult.BingTotal);

            Assert.AreEqual(js, result.GoogleWinner);
            Assert.AreEqual(cSharp, result.BingWinner);
        }
    }
}
