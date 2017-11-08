using Microsoft.AspNetCore.Mvc;

namespace GenialO.Controllers
{
    public class HomeController : Controller
    {

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
