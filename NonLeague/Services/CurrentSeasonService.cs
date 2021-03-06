
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using NonLeague.Models;

namespace NonLeague.Services
{
    public class CurrentSeasonService : ISeasonService
    {
        public IEnumerable<Month> GetSeason(string webRoot)
        {
            var season = from element in XDocument.Load(webRoot + "/xml/season.xml").Descendants("month") select element;
            
            List<Month> seasonList = new List<Month>();
            
            foreach (var item in season)
            {
                seasonList.Add(new Month() {
                    Name = item.Attribute("name").Value,
                    ID = Convert.ToInt32(item.Attribute("ID").Value)
                });
            }
            
            return seasonList; 
            
        }
    }
    
}