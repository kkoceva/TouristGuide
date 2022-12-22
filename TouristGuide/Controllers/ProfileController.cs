using Microsoft.AspNetCore.Mvc;

namespace TouristGuide.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
