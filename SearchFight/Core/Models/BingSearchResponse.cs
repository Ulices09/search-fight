using System;
using System.Collections.Generic;
using System.Text;

namespace SearchFight.Core.Models
{
    public class BingSearchResponse
    {
        public BingSearchWebPages WebPages { get; set; }
    }

    public class BingSearchWebPages
    {
        public int TotalEstimatedMatches { get; set; }
    }
}
