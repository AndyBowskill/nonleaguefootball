using Microsoft.AspNetCore.Mvc;
using NonLeague.Services;
using System.Threading.Tasks;

namespace NonLeague.Controllers
{
    public class MatchThisWeekController : Controller
    {
        private readonly IMatchService _matchService;
        
        public MatchThisWeekController(IMatchService matchService)
        {
            _matchService = matchService;
        }
        
        [Route("fixturesandresults/today")]
        public async Task<IActionResult> Index()
        {
            return View(await _matchService.GetFixturesForToday());
        }
        
    }
}