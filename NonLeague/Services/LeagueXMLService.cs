using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using NonLeague.Models;

namespace NonLeague.Services
{
    public class LeagueXMLService : ILeagueService
    {
        private List<League> leagueList;
         
        public IEnumerable<League> GetAll(string webRoot)
        {
            var leagues = from element in XDocument.Load(webRoot + "/xml/leagues.xml").Descendants("league") select element;

            leagueList = new List<League>();
            
            foreach (var item in leagues)
            {
                leagueList.Add(new League() {
                    Name = item.Attribute("name").Value,
                    Division = item.Attribute("division").Value,
                    Sponsor = item.Attribute("sponsor").Value,
                    Step = Convert.ToInt32(item.Attribute("step").Value),
                    CompetitionID = Convert.ToInt32(item.Attribute("competitionID").Value)
                });
            }
            
            return leagueList;
            
        }
        
        public string GetDescription(int competitionID, string webRoot)
        {
            // ToDo - Prevent exception if user uses URL to ask for a competition that doesn't exist (e.g. 1,2,3,etc.)
            
            if (leagueList == null)
            {
                leagueList = GetAll(webRoot).ToList();
            }
            
            League league = leagueList.First(item => item.CompetitionID == competitionID);            
            
            return string.Format("{0} - {1}", league.Name, league.Division);

        }
    }
    
}