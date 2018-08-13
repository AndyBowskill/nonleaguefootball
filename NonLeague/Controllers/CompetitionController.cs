using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NonLeague.Models;
using NonLeague.Services;

namespace NonLeague.Controllers
{
    public class CompetitionController : Controller
    {
        private readonly ILeagueService _leagueService;
        private readonly IHostingEnvironment _hostingEnvironment;

        public CompetitionController(ILeagueService leagueService, IHostingEnvironment hostingEnvironment)
        {
            _leagueService = leagueService;
            _hostingEnvironment = hostingEnvironment;
        }

        [Route("match/[controller]")]
        [Route("")]
        public IActionResult Match()
        {            
            var model = _leagueService.GetAll(_hostingEnvironment.WebRootPath);

            return View(model);
        }

        [Route("table/[controller]")]
        public IActionResult Table()
        {
            var model = _leagueService.GetAll(_hostingEnvironment.WebRootPath);

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
