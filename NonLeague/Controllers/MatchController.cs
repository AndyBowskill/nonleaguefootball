using Microsoft.AspNetCore.Mvc;
using NonLeague.Services;
using System.Threading.Tasks;

namespace NonLeague.Controllers
{
    public class MatchController : Controller
    {
        private readonly IMatchService _matchService;
        
        public MatchController(IMatchService matchService)
        {
            _matchService = matchService;
        }
        
        [Route("fixturesandresults/season/details")]
        [HttpGet("{competitionid:int}")]
        [HttpGet("{monthid:int}")]
        public async Task<IActionResult> Index(int competitionID, int monthID)
        {
            return View(await _matchService.GetFixturesForMonth(competitionID, monthID));
        }
        
    }
}