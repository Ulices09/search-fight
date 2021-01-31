using SearchFight.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Services.Interfaces
{
    public interface ISearchFightService
    {
        Task<SearchFightResult> SearchFight(string[] programmingLanguages);
    }
}
