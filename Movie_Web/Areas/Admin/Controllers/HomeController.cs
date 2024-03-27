using Microsoft.AspNetCore.Mvc;

namespace Movie_Web.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
