using System.Collections.Generic;
using NonLeague.Models;

namespace NonLeague.Services
{
    public interface ILeagueService
    {
        IEnumerable<League> GetAll();
        string GetDescription(int competitionID);
    }
    
}