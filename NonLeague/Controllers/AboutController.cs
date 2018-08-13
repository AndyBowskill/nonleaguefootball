using Microsoft.AspNetCore.Mvc;

namespace NonLeague.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {   
            return View();
        }

    }
}
