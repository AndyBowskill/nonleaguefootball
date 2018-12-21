using Microsoft.AspNetCore.Mvc;
using Moq;
using NonLeague.Controllers;
using NonLeague.Models;
using NonLeague.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Tests.UnitTests
{
    public class TableControllerUnitTests
    {
        [Fact]
        public async Task Index_ReturnsWithAViewResult_WithALeagueTable()
        {   
            // Arrange
            int tableID = 5;
            var serviceMock = new Mock<ITableService>();
            serviceMock.Setup(x => x.GetTable(tableID)).ReturnsAsync(GetTestLeagueTable());
            var controller = new TableController(serviceMock.Object);

            // Act
            var result = await controller.Index(tableID);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<LeagueTable>(viewResult.ViewData.Model);
            Assert.Equal(2, model.Team.Count());
        }

        private LeagueTable GetTestLeagueTable()
        {
            var leagueTable = new LeagueTable();
            leagueTable.Competition = "National League";
            leagueTable.Description = "League Table";
            leagueTable.Team = new List<Team>();
            leagueTable.Team.Add(new Team()
            {
                Position = "1",
                Name = "Leyton Orient",
                Played = "24",
                Won = "14",
                Drawn = "8",
                Lost = "2",
                For = "44",
                Against = "14",
                GoalDifference = "+30",
                Points = "50"
            });
            leagueTable.Team.Add(new Team()
            {
                Position = "2",
                Name = "Salford City",
                Played = "24",
                Won = "14",
                Drawn = "7",
                Lost = "3",
                For = "47",
                Against = "21",
                GoalDifference = "+26",
                Points = "49"
            });

            return leagueTable;
        }
    }
}
