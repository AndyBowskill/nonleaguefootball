using System.Threading.Tasks;
using NonLeague.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace NonLeague.Services
{
    public class CurrentMatchService : IMatchService
    {
        public async Task<MatchesCompetition> GetFixturesForMonth(int competitionID, int monthID)
        {
            string responseJson = "";
            MatchesCompetitionRoot root = new MatchesCompetitionRoot();
            MatchesCompetition monthsMatches = new MatchesCompetition();
            
            using (var client = new HttpClient())
            {
                var URI = string.Format("https://www.footballwebpages.co.uk/fixtures-results.json?comp={0}&month={1}",competitionID, monthID);
                client.BaseAddress = new Uri(URI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync(URI);
        
                if (response.IsSuccessStatusCode)
                {
                    responseJson = await response.Content.ReadAsStringAsync();
                    root = JsonConvert.DeserializeObject<MatchesCompetitionRoot>(responseJson);
                    monthsMatches = root.MatchesCompetition;
                }

            }
            
            return monthsMatches;

        }

        public async Task<List<MatchesCompetition>> GetFixturesForToday()
        {
            string responseJson = "";
            MatchesCompetitionRoot root = null;
            List<MatchesCompetition> thisWeeksMatches = new List<MatchesCompetition>();

            int[] competitionsID = { 5, 6, 7, 14, 8, 39, 11, 15, 16, 9, 10, 12, 13, 40 };

            foreach (int competitionID in competitionsID)
            {
                using (var client = new HttpClient())
                {
                    var URI = string.Format("https://www.footballwebpages.co.uk/fixtures-results.json?comp={0}&fixtures=1&results=1", competitionID);
                    client.BaseAddress = new Uri(URI);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = await client.GetAsync(URI);

                    if (response.IsSuccessStatusCode)
                    {
                        responseJson = await response.Content.ReadAsStringAsync();
                        root = JsonConvert.DeserializeObject<MatchesCompetitionRoot>(responseJson);
                        thisWeeksMatches.Add(root.MatchesCompetition);  
                    }
                }
            }

            return thisWeeksMatches;

        }
    }
    
}