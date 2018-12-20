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
    public class MatchControllerUnitTests
    {
        [Fact]
        public async Task Index_ReturnsWithAViewResult_WithAMatchesCompetition()
        {
            // Arrange
            int competitionID = 5;
            int monthID = 8;
            var serviceMock = new Mock<IMatchService>();
            serviceMock.Setup(x => x.GetFixturesForMonth(competitionID, monthID)).ReturnsAsync(GetTestMatchesCompetition());
            var controller = new MatchController(serviceMock.Object);

            // Act
            var result = await controller.Index(competitionID, monthID);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<MatchesCompetition>(viewResult.ViewData.Model);
            Assert.Equal(2, model.Match.Count());
        }

        private MatchesCompetition GetTestMatchesCompetition()
        {
            var matchesCompetition = new MatchesCompetition();
            matchesCompetition.Competition = "National League";
            matchesCompetition.Description = "Fixtures / Results";
            matchesCompetition.Match = new List<Match>();
            matchesCompetition.Match.Add(new Match()
            {
                Date = "Saturday 4th August 2018",
                Time= "15:00:00",
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

            return matchesCompetition;
        }
    }
}
