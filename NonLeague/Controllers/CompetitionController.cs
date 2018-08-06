using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NonLeague.Models;
using NonLeague.Services;

namespace NonLeague.Controllers
{
    public class CompetitionController : Controller
    {
        private readonly ILeagueService _leagueService;

        public CompetitionController(ILeagueService leagueService)
        {
            _leagueService = leagueService;
        }

        [Route("Match/[controller]")]
        [Route("/")]
        public IActionResult Match()
        {
            var model = _leagueService.GetAll();

            return View(model);
        }

        [Route("Table/[controller]")]
        public IActionResult Table()
        {
            var model = _leagueService.GetAll();

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
