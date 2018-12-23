using System.Collections.Generic;
using NonLeague.Models;

namespace NonLeague.ViewModels
{
    public class LeagueSeason
    {
        public int CompetitionID { get; set; }
        public string Competition { get; set; }
        public IEnumerable<Month> Season { get; set; }

    }
}