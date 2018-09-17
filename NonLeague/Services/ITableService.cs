using System.Threading.Tasks;
using NonLeague.Models;

namespace NonLeague.Services
{
    public interface ITableService
    {
        Task<LeagueTable> GetTable(int competitionID);
    }
    
}