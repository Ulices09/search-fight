using System;
using System.Collections.Generic;
using System.Text;

namespace SearchFight.Core.Models
{
    public class SearchFightResult
    {
        public List<ProgrammingLanguageResult> ProgrammingLanguageResults { get; set; }
        public string GoogleWinner { get; set; }
        public string BingWinner { get; set; }
        public string TotalWinner { get; set; }
    }
}
