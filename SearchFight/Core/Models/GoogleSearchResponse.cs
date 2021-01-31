using System;
using System.Collections.Generic;
using System.Text;

namespace SearchFight.Core.Models
{
    public class GoogleSearchResponse
    {
        public GoogleSearchInformation SearchInformation { get; set; }
    }

    public class GoogleSearchInformation
    {
        public string totalResults { get; set; }
    }
}
