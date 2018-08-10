using System.Threading.Tasks;
using NonLeague.Models;

namespace NonLeague.Services
{
    public interface ITableService
    {
        Task<LeagueTableRoot> GetTable(int competitionID);
    }
    
}