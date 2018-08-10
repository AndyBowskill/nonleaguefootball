using System.Collections.Generic;
using NonLeague.Models;

namespace NonLeague.Services
{
    public interface ILeagueService
    {
        IEnumerable<League> GetAll(string webRoot);
        string GetDescription(int competitionID, string webRoot);
    }
    
}