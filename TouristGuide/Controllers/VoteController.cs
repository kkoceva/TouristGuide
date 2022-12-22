using Microsoft.AspNetCore.Mvc;

namespace TouristGuide.Controllers
{
    public class VoteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
