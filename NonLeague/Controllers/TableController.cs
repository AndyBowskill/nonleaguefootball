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
        
        [Route("Table/Competition/{compID:int}/[controller]")]
        public async Task<IActionResult> Index(int compID)
        {
            //ToDo - Return league table node from service
            var leagueTableRoot = await _leagueTableService.GetTable(compID);

            var leagueTableHelper = new LeagueTableHelper();
            leagueTableHelper.Description = _leagueService.GetDescription(compID, _hostingEnvironment.WebRootPath);
            leagueTableHelper.LeagueTable = leagueTableRoot.LeagueTable;

            return View(leagueTableHelper);
        }
        
    }
}