using System.Collections.Generic;
using NonLeague.Models;

namespace NonLeague.Services
{
    public interface ILeagueService
    {
        IEnumerable<League> GetAll(string webRoot);
        string GetCompetition(int competitionID, string webRoot);
    }
    
}