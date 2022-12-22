using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using TouristGuide.Core.Contracts;
using TouristGuide.Models;
using static TouristGuide.Areas.Admin.Constants.AdminConstants;

namespace TouristGuide.Controllers
{
    public class HomeController : Controller
    {

        private readonly IPlaceService placeService;
        private readonly ILogger logger;

        public HomeController(
           IPlaceService _placeService,
           ILogger<HomeController> _logger)
        {
            placeService = _placeService;
            logger = _logger;
        }

        public async Task<IActionResult> Index()
        {
            if (User.IsInRole(AdminRoleName))
            {
                return RedirectToAction("Index", "Admin", new { area = "Admin" });
            }

            var model = await placeService.LastThreePlaces();

            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var feature = this.HttpContext.Features.Get<IExceptionHandlerFeature>();

            logger.LogError(feature.Error, "TraceIdentifier: {0}", Activity.Current?.Id ?? HttpContext.TraceIdentifier);

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}