using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NonLeague.Helper;
using NonLeague.Services;

namespace NonLeague.Controllers
{
    public class SeasonController : Controller
    {
        private readonly ISeasonService _seasonService;
        private readonly ILeagueService _leagueService;
        private readonly IHostingEnvironment _hostingEnvironment;

        public SeasonController(ISeasonService seasonService, ILeagueService leagueService, IHostingEnvironment hostingEnvironment)
        {
            _seasonService = seasonService;
            _leagueService = leagueService;
            _hostingEnvironment = hostingEnvironment;
        }

        [Route("fixturesandresults/[controller]")]
        [HttpGet("{competitionID:int}")]
        public IActionResult Index(int competitionID)
        {
            var leagueSeasonHelper = new LeagueSeasonHelper
            {
                CompetitionID = competitionID,
                Competition = _leagueService.GetCompetition(competitionID, _hostingEnvironment.WebRootPath),
                Season = _seasonService.GetSeason(_hostingEnvironment.WebRootPath)
            };

            return View(leagueSeasonHelper);
        }

    }
}
