using Microsoft.AspNetCore.Mvc;

namespace TouristGuide.Controllers
{
    public class RatingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
