
using Microsoft.AspNetCore.Mvc;
using TouristGuide.Areas.Admin.Models;
using TouristGuide.Core.Contracts;
using TouristGuide.Core.Models.Place;
using TouristGuide.Extensions;

namespace TouristGuide.Areas.Admin.Controllers
{
    public class PlaceController : BaseController
    {
        private readonly IPlaceService placeService;

        public PlaceController(
            IPlaceService _placeService)
        {
            placeService = _placeService;
            
        }

        public async Task<IActionResult> Mine()
        {
            var myPlaces = new MyPlacesViewModel();
            var adminId = User.Id();

            myPlaces.AddedPlaces = await placeService.AllPlacesByUserId(adminId);

            return View(myPlaces);
        }
    }
}
