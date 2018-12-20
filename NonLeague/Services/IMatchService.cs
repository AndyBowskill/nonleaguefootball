using System.Collections.Generic;
using System.Threading.Tasks;
using NonLeague.Models;

namespace NonLeague.Services
{
    public interface IMatchService
    {
        Task<MatchesCompetition> GetFixturesForMonth(int competitionID, int monthID);
        Task<List<MatchesCompetition>> GetFixturesForToday();
    }
    
}