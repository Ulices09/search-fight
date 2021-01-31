using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.HttpClients.Interfaces
{
    public interface ISearchHttpClient
    {
        Task<int> GetGoogleResults(string programmingLanguage);
        Task<int> GetBingResults(string programmingLanguage);
    }
}
