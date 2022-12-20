using Microsoft.AspNetCore.Mvc;

namespace TouristGuide.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
