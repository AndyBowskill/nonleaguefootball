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
            var leagues = GetLeaguesFromXML(webRoot);
            string leagueDescription = null;

            foreach (var item in leagues)
            {
                if (competitionID == Convert.ToInt32(item.Attribute("competitionID").Value))
                {
                   leagueDescription = string.Format("{0} - {1}", item.Attribute("name").Value, item.Attribute("division").Value);
                   break;
                }
         
            }

            if (leagueDescription == null)
            {
                leagueDescription = "N/A";
            }

            return leagueDescription;
        }

        private IEnumerable<XElement> GetLeaguesFromXML(string webRoot)
        {
            return from element in XDocument.Load(webRoot + "/xml/leagues.xml").Descendants("league") select element;
        }
    }
}