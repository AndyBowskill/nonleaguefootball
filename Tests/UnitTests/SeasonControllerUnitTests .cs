using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NonLeague.Controllers;
using NonLeague.Models;
using NonLeague.Services;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests.UnitTests
{
    public class SeasonControllerUnitTests
    {
        [Fact]
        public void Index_ReturnsWithAViewResult_WithAListOfMonths()
        {
            // Arrange
            int competitionID = 5;
            var seasonMock = new Mock<ISeasonService>();
            var leagueMock = new Mock<ILeagueService>();
            var hostingMock = new Mock<IHostingEnvironment>();

            leagueMock.Setup(x => x.GetCompetition(competitionID, hostingMock.Object.WebRootPath)).Returns(GetTestCompetition());
            seasonMock.Setup(x => x.GetSeason(hostingMock.Object.WebRootPath)).Returns(GetTestSeason());

            var controller = new SeasonController(seasonMock.Object, leagueMock.Object, hostingMock.Object);

            // Act
            var result = controller.Index(competitionID);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Month>>(viewResult.ViewData.Model);
            Assert.Equal(3, model.Count());
        }

        private string GetTestCompetition()
        {
            return "Vanarama National League";
        }

        private IEnumerable<Month> GetTestSeason()
        {
            var seasonList = new List<Month>() {
                new Month() { ID = 8, Name = "August" },
                new Month() { ID = 9, Name = "September" },
                new Month() { ID = 10, Name = "October" },
            };

            return seasonList;
        }
    }
}
