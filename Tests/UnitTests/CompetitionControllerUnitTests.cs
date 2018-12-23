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
    public class CompetitionControllerUnitTests
    {
        [Fact]
        public void FixturesAndResults_ReturnsWithAViewResult_WithAListOfLeagues()
        {
            // Arrange
            var serviceMock = new Mock<ILeagueService>();
            var hostingMock = new Mock<IHostingEnvironment>();

            serviceMock.Setup(x => x.GetAll(hostingMock.Object.WebRootPath)).Returns(GetTestLeagues());
            var controller = new CompetitionController(serviceMock.Object, hostingMock.Object);

            // Act
            var result = controller.FixturesAndResults();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<League>>(viewResult.ViewData.Model);
            Assert.Equal(3, model.Count());
        }

        [Fact]
        public void Table_ReturnsWithAViewResult_WithAListOfLeagues()
        {
            // Arrange
            var leagueMock = new Mock<ILeagueService>();
            var hostingMock = new Mock<IHostingEnvironment>();

            leagueMock.Setup(x => x.GetAll(hostingMock.Object.WebRootPath)).Returns(GetTestLeagues());

            var controller = new CompetitionController(leagueMock.Object, hostingMock.Object);

            // Act
            var result = controller.Table();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<League>>(viewResult.ViewData.Model);
            Assert.Equal(3, model.Count());
        }

        private List<League> GetTestLeagues()
        {
            var leagueList = new List<League>() {
                new League() { Competition = "Vanarama National League South", CompetitionID = 7, Step = 2 },
                new League() { Competition = "Evo-Stik League Premier Division", CompetitionID = 14, Step = 3 },
                new League() { Competition = "Evo-Stik Southern Premier Central", CompetitionID = 8, Step = 3 }
            };

            return leagueList;
        }
    }
}
