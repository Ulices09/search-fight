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
    public class SearchServiceTests
    {
        [TestMethod]
        public async Task SearchProgrammingLanguageResults()
        {
            string programmingLanguage = "C#";
            int googleTotal = 9878987;
            int bingTotal = 3434234;

            var searchHttpClient = new Mock<ISearchHttpClient>();
            searchHttpClient
                .Setup(x => x.GetGoogleResults(programmingLanguage))
                .Returns(Task.FromResult(googleTotal));
            searchHttpClient
                .Setup(x => x.GetBingResults(programmingLanguage))
                .Returns(Task.FromResult(bingTotal));

            var searchService = new SearchService(searchHttpClient.Object);
            var result = await searchService.SearchProgrammingLanguageResults(programmingLanguage);

            Assert.AreEqual(programmingLanguage, result.ProgrammingLanguage);
            Assert.AreEqual(googleTotal, result.GoogleTotal);
            Assert.AreEqual(bingTotal, result.BingTotal);
        }
    }
}
