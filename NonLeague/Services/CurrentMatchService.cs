using Newtonsoft.Json;
using NonLeague.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NonLeague.Services
{
    public class CurrentMatchService : IMatchService
    {
        public async Task<MatchesCompetition> GetFixturesForMonth(int competitionID, int monthID)
        {
            var URI = $"fixtures-results.json?comp={ competitionID }&month={ monthID}";

            using (var response = await APIClient.Client.GetAsync(URI))
            {        
                if (response.IsSuccessStatusCode)
                {
                    string responseJson = await response.Content.ReadAsStringAsync();
                    MatchesCompetitionRoot root = JsonConvert.DeserializeObject<MatchesCompetitionRoot>(responseJson);
                    return root.MatchesCompetition;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }

            }
        }

        public async Task<List<MatchesCompetition>> GetFixturesForToday()
        {
            List<MatchesCompetition> thisWeeksMatches = new List<MatchesCompetition>();

            int[] competitionsID = { 5, 6, 7, 14, 8, 39, 11, 15, 16, 9, 10, 12, 13, 40 };

            foreach (int competitionID in competitionsID)
            {
                var URI = $"fixtures-results.json?comp={ competitionID }&fixtures=1&results=1";

                using (var response = await APIClient.Client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseJson = await response.Content.ReadAsStringAsync();
                        MatchesCompetitionRoot root = JsonConvert.DeserializeObject<MatchesCompetitionRoot>(responseJson);
                        thisWeeksMatches.Add(root.MatchesCompetition);  
                    }
                    else
                    {
                        throw new Exception(response.ReasonPhrase);
                    }
                }
            }

            return thisWeeksMatches;
        }
    }
    
}