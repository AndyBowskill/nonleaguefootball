using System.Collections.Generic;
using NonLeague.Models;

namespace NonLeague.Services
{
    public interface ISeasonService
    {
        IEnumerable<Month> GetSeason(string webRoot);
    }
    
}