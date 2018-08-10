using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using NonLeague.Models;
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
        
        [Route("Match/Competition/{compID:int}/[controller]")]
        public IActionResult Index(int compID)
        {
            var leagueSeasonHelper = new LeagueSeasonHelper();
            leagueSeasonHelper.CompetitionID = compID;
            leagueSeasonHelper.Description = _leagueService.GetDescription(compID, _hostingEnvironment.WebRootPath);
            leagueSeasonHelper.Season = _seasonService.GetSeason(_hostingEnvironment.WebRootPath);

            return View(leagueSeasonHelper);
        }

    }
}
