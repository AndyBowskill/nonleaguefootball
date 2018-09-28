using Newtonsoft.Json;
using NonLeague.Models;
using System;
using System.Threading.Tasks;

namespace NonLeague.Services
{
    public class LeagueTableService : ITableService
    {
        public async Task<LeagueTable> GetTable(int competitionID)
        {
            var URI = $"league.json?comp={ competitionID }";

            using (var response = await APIClient.Client.GetAsync(URI))
            {
                if (response.IsSuccessStatusCode)
                {
                    string responseJson = await response.Content.ReadAsStringAsync();
                    LeagueTableRoot root = JsonConvert.DeserializeObject<LeagueTableRoot>(responseJson);

                    return root.LeagueTable;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }                  
            }
        }
    }
    
}