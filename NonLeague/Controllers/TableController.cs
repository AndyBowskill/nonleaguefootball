using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NonLeague.Models;
using NonLeague.Helper;
using NonLeague.Services;

namespace NonLeague.Controllers
{
    public class TableController : Controller
    {
        private readonly ILeagueService _leagueService;
        private readonly ITableService _leagueTableService;
        
        public TableController(ILeagueService leagueService, ITableService leagueTableService)
        {
            _leagueService = leagueService;
            _leagueTableService = leagueTableService;
        }
        
        [Route("Table/Competition/{compID:int}/[controller]")]
        public async Task<IActionResult> Index(int compID)
        {
            //ToDo - Return league table node from service
            var leagueTableRoot = await _leagueTableService.GetTable(compID);

            var leagueTableHelper = new LeagueTableHelper();
            leagueTableHelper.Description = _leagueService.GetDescription(compID);
            leagueTableHelper.LeagueTable = leagueTableRoot.LeagueTable;

            return View(leagueTableHelper);
        }
        
    }
}