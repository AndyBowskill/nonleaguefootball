using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NonLeague.Models;

namespace NonLeague.Services
{
    public class LeagueTableService : ITableService
    {
        public async Task<LeagueTable> GetTable(int competitionID)
        {
            string responseJson = "";
            LeagueTableRoot root = new LeagueTableRoot();
            LeagueTable leagueTable = new LeagueTable();
            
            using (var client = new HttpClient())
            {
                var URI = string.Format("https://www.footballwebpages.co.uk/league.json?comp={0}",competitionID);
                client.BaseAddress = new Uri(URI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync(URI);
        
                if (response.IsSuccessStatusCode)
                {
                    responseJson = await response.Content.ReadAsStringAsync();
                    root = JsonConvert.DeserializeObject<LeagueTableRoot>(responseJson);
                    leagueTable = root.LeagueTable;
                }
            }
            
            return leagueTable;
            
        }
    }
    
}