using Microsoft.AspNetCore.Mvc;

namespace TouristGuide.Controllers
{
    public class PlaceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
