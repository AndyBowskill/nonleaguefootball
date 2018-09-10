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
            var leagueSeasonHelper = new LeagueSeasonHelper();
            leagueSeasonHelper.CompetitionID = competitionID;
            leagueSeasonHelper.Description = _leagueService.GetDescription(competitionID, _hostingEnvironment.WebRootPath);
            leagueSeasonHelper.Season = _seasonService.GetSeason(_hostingEnvironment.WebRootPath);

            return View(leagueSeasonHelper);
        }

    }
}
