using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using NonLeague.Models;
using NonLeague.Helper;
using NonLeague.Services;

namespace NonLeague.Controllers
{
    public class MatchThisWeekController : Controller
    {
        private readonly IMatchService _matchService;
        private readonly ILeagueService _leagueService;
        private readonly IHostingEnvironment _hostingEnvironment;
        
        public MatchThisWeekController(IMatchService matchService, ILeagueService leagueService, IHostingEnvironment hostingEnvironment)
        {
            _matchService = matchService;
            _leagueService = leagueService;
            _hostingEnvironment = hostingEnvironment;
        }
        
        [Route("fixturesandresults/today")]
        public async Task<IActionResult> Index()
        {

            return View(await _matchService.GetFixturesForToday());
        }
        
    }
}