using Microsoft.AspNetCore.Mvc;

namespace NetCoreProcessMonitoring.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(){
            return View();
        }
    }
}