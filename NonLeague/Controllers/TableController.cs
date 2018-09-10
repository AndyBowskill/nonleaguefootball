using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using NonLeague.Models;
using NonLeague.Helper;
using NonLeague.Services;

namespace NonLeague.Controllers
{
    public class TableController : Controller
    {
        private readonly ILeagueService _leagueService;
        private readonly ITableService _leagueTableService;
        private readonly IHostingEnvironment _hostingEnvironment;
        
        public TableController(ILeagueService leagueService, ITableService leagueTableService, IHostingEnvironment hostingEnvironment)
        {
            _leagueService = leagueService;
            _leagueTableService = leagueTableService;
            _hostingEnvironment = hostingEnvironment;
        }
        
        [Route("tables/details")]
        [HttpGet("{competitionID:int}")]
        public async Task<IActionResult> Index(int competitionID)
        {
            //ToDo - Return league table node from service
            var leagueTableRoot = await _leagueTableService.GetTable(competitionID);

            var leagueTableHelper = new LeagueTableHelper();
            leagueTableHelper.Description = _leagueService.GetDescription(competitionID, _hostingEnvironment.WebRootPath);
            leagueTableHelper.LeagueTable = leagueTableRoot.LeagueTable;

            return View(leagueTableHelper);
        }
        
    }
}