using Microsoft.AspNetCore.Mvc;
using NonLeague.Services;
using System.Threading.Tasks;

namespace NonLeague.Controllers
{
    public class TableController : Controller
    {
        private readonly ITableService _leagueTableService;
        
        public TableController(ITableService leagueTableService)
        {
            _leagueTableService = leagueTableService;
        }
        
        [Route("tables/details")]
        [HttpGet("{competitionID:int}")]
        public async Task<IActionResult> Index(int competitionID)
        {
            return View(await _leagueTableService.GetTable(competitionID));
        }
        
    }
}