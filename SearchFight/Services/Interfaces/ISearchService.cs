using SearchFight.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchFight.Services.Interfaces
{
    public interface ISearchService
    {
        ProgrammingLanguageResult SearchProgrammingLanguageResults(string programmingLanguage);
    }
}
