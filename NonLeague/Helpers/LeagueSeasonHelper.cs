using System.Collections.Generic;
using NonLeague.Models;

namespace NonLeague.Helper
{
    public class LeagueSeasonHelper
    {
        public int CompetitionID { get; set; }
        public string Description { get; set; }
        public IEnumerable<Month> Season { get; set; }

    }
}