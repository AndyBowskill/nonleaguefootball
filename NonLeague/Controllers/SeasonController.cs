using Microsoft.AspNetCore.Mvc;
using NonLeague.Models;
using NonLeague.Helper;
using NonLeague.Services;

namespace NonLeague.Controllers
{
    public class SeasonController : Controller
    {
        private readonly ISeasonService _seasonService;
        private readonly ILeagueService _leagueService;
        
        public SeasonController(ISeasonService seasonService, ILeagueService leagueService)
        {
            _seasonService = seasonService;
            _leagueService = leagueService;
        }
        
        [Route("Match/Competition/{compID:int}/[controller]")]
        public IActionResult Index(int compID)
        {
            var leagueSeasonHelper = new LeagueSeasonHelper();
            leagueSeasonHelper.CompetitionID = compID;
            leagueSeasonHelper.Description = _leagueService.GetDescription(compID);
            leagueSeasonHelper.Season = _seasonService.GetSeason();

            return View(leagueSeasonHelper);
        }

    }
}
