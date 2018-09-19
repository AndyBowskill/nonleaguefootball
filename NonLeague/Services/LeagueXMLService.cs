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
            var leagues = GetLeaguesFromXML(webRoot);
            leagueList = new List<League>();
            
            foreach (var item in leagues)
            {
                leagueList.Add(new League() {
                    Competition = item.Attribute("competition").Value,
                    Step = Convert.ToInt32(item.Attribute("step").Value),
                    CompetitionID = Convert.ToInt32(item.Attribute("competitionID").Value)
                });
            }
            
            return leagueList;
        }

        public string GetCompetition(int competitionID, string webRoot)
        {
            var leagues = GetLeaguesFromXML(webRoot);
            string competition = null;

            foreach (var item in leagues)
            {
                if (competitionID == Convert.ToInt32(item.Attribute("competitionID").Value))
                {
                   competition = item.Attribute("competition").Value;
                   break;
                }
         
            }

            if (competition == null)
            {
                competition = "N/A";
            }

            return competition;
        }

        private IEnumerable<XElement> GetLeaguesFromXML(string webRoot)
        {
            return from element in XDocument.Load(webRoot + "/xml/leagues.xml").Descendants("league") select element;
        }
    }
}