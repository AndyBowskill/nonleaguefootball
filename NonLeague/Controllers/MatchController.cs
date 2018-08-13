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
        
        [Route("match/competition/{compID:int}/season/{monthID:int}")]
        public async Task<IActionResult> Index(int compID, int monthID)
        {
            //ToDo - Return matches node from service
            var matchesCompetitionRoot = await _matchService.GetFixturesForMonth(compID, monthID);

            var matchesCompetitionHelper = new MatchesCompetitionHelper();
            matchesCompetitionHelper.Description = _leagueService.GetDescription(compID, _hostingEnvironment.WebRootPath);
            matchesCompetitionHelper.MatchesCompetition = matchesCompetitionRoot.MatchesCompetition;

            return View(matchesCompetitionHelper);
        }
        
    }
}