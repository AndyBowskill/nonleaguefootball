using Microsoft.AspNetCore.Mvc;
using Moq;
using NonLeague.Controllers;
using NonLeague.Models;
using NonLeague.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Match = NonLeague.Models.Match;

namespace Tests.UnitTests
{
    public class MatchThisWeekControllerUnitTests
    {
        [Fact]
        public async Task Index_ReturnsWithAViewResult_WithAListOfMatchesCompetitions()
        {
            // Arrange
            var serviceMock = new Mock<IMatchService>();
            serviceMock.Setup(x => x.GetFixturesForToday()).ReturnsAsync(GetTestMatchesCompetitions());
            var controller = new MatchThisWeekController(serviceMock.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<MatchesCompetition>>(viewResult.ViewData.Model);
            
            for (int i = 0; i < model.Count(); i++)
            {
                Assert.Equal(2, model[i].Match.Count());
            }
        }

        private List<MatchesCompetition> GetTestMatchesCompetitions()
        {
            var thisWeeksMatches = new List<MatchesCompetition>();

            int competitionCount = 0;
            while (++competitionCount < + 2)
            {
                var matchesCompetition = new MatchesCompetition();
                matchesCompetition.Competition = "National League";
                matchesCompetition.Description = "Fixtures / Results";
                matchesCompetition.Match = new List<Match>();
                matchesCompetition.Match.Add(new Match()
                {
                    Date = "Saturday 4th August 2018",
                    Time = "15:00:00",
                    Status = "Full Time",
                    HomeTeamName = "AFC Fylde",
                    HomeTeamHalfTimeScore = 1,
                    HomeTeamScore = 2,
                    AwayTeamHalfTimeScore = 0,
                    AwayTeamScore = 1,
                    AwayTeamName = "Bromley",
                    Attendance = 1227
                });
                matchesCompetition.Match.Add(new Match()
                {
                    Date = "Tuesday 7th August 2018",
                    Time = "19:45:00",
                    Status = "Full Time",
                    HomeTeamName = "Havant & Waterlooville",
                    HomeTeamHalfTimeScore = 0,
                    HomeTeamScore = 0,
                    AwayTeamHalfTimeScore = 0,
                    AwayTeamScore = 0,
                    AwayTeamName = "Boreham Wood",
                    Attendance = 1348
                });

                thisWeeksMatches.Add(matchesCompetition);
            }

            return thisWeeksMatches;
        }

    }
}
