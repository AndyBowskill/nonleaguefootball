using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using NonLeague.Models;
using NonLeague.Helper;
using NonLeague.Services;

namespace NonLeague.Controllers
{
    public class MatchController : Controller
    {
        private readonly IMatchService _matchService;
        private readonly ILeagueService _leagueService;
        private readonly IHostingEnvironment _hostingEnvironment;
        
        public MatchController(IMatchService matchService, ILeagueService leagueService, IHostingEnvironment hostingEnvironment)
        {
            _matchService = matchService;
            _leagueService = leagueService;
            _hostingEnvironment = hostingEnvironment;
        }
        
        [Route("fixturesandresults/season/details")]
        [HttpGet("{competitionid:int}")]
        [HttpGet("{monthid:int}")]
        public async Task<IActionResult> Index(int competitionID, int monthID)
        {
            //ToDo - Return matches node from service
            var matchesCompetitionRoot = await _matchService.GetFixturesForMonth(competitionID, monthID);

            var matchesCompetitionHelper = new MatchesCompetitionHelper();
            matchesCompetitionHelper.Description = _leagueService.GetDescription(competitionID, _hostingEnvironment.WebRootPath);
            matchesCompetitionHelper.MatchesCompetition = matchesCompetitionRoot.MatchesCompetition;

            return View(matchesCompetitionHelper);
        }
        
    }
}