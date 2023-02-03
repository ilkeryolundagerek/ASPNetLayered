using Microsoft.AspNetCore.Mvc;

namespace UI.MVC.Areas.tr.Controllers
{
    [Area("tr")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
