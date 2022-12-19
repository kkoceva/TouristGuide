using Microsoft.AspNetCore.Mvc;

namespace TouristGuide.Controllers
{
    public class BaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
