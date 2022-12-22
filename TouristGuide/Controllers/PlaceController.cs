using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TouristGuide.Core.Contracts;
using TouristGuide.Core.Models.Place;
using TouristGuide.Models;

namespace TouristGuide.Controllers
{
    public class PlaceController : Controller
    {
        private readonly IPlaceService placeService;

      
        private readonly ILogger logger;

        public PlaceController(
            IPlaceService _placeService,
           
            ILogger<PlaceController> _logger)
        {
            placeService = _placeService;
            logger = _logger;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery] AllPlacesQueryModel query)
        {
            var result = await placeService.All(
                query.Category,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllPlacesQueryModel.PlacesPerPage);

            query.TotalPlacesCount = result.TotalPlacesCount;
            query.Categories = await placeService.AllCategoriesNames();
            query.Places = result.Places;

            return View(query);
        }

        //public async Task<IActionResult> Mine()
        //{
        //    //if (User.IsInRole(AdminRolleName))
        //    //{
        //    //    return RedirectToAction("Mine", "place", new { area = AreaName });
        //    //}
        //    //var userId = User.Claims.Claims
        //    //IEnumerable<PlaceServiceModel> myPlaces;

        //    //myPlaces = await placeService.AllPlacesByUserId(userId);

        //    return View(myPlaces);
        //}

        [AllowAnonymous]
        public async Task<IActionResult> Details(string id, string information)
        {
            if ((await placeService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            var model = await placeService.PlaceDetailsById(id);

            //if (information != model.GetInformation())
            //{
            //    TempData["ErrorMessage"] = "Don't touch my slug!";

            //    return RedirectToAction("Index", "Home");
            //}

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {

            var model = new PlaceModel()
            {
                PlaceCategories = await placeService.AllCategories()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PlaceModel model)
        {
            if ((await placeService.CategoryExists(model.CategoryId)) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exists");
            }

            if (!ModelState.IsValid)
            {
                model.PlaceCategories = await placeService.AllCategories();

                return View(model);
            }

            string id = await placeService.Create(model);

            return RedirectToAction(nameof(Details), new { id = id});
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if ((await placeService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            var place = await placeService.PlaceDetailsById(id);
            var categoryId = await placeService.GetPlaceCategoryId(id);

            var model = new PlaceModel()
            {
                Id = id,
                CategoryId = categoryId,
                Description = place.Description,
                ImageUrl = place.ImageUrl,
             
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, PlaceModel model)
        {
            if (id != model.Id)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            if ((await placeService.Exists(model.Id)) == false)
            {
                ModelState.AddModelError("", "Place does not exist");
                model.PlaceCategories = await placeService.AllCategories();

                return View(model);
            }

            if ((await placeService.CategoryExists(model.CategoryId)) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
                model.PlaceCategories = await placeService.AllCategories();

                return View(model);
            }

            if (ModelState.IsValid == false)
            {
                model.PlaceCategories = await placeService.AllCategories();

                return View(model);
            }

            await placeService.Edit(model.Id, model);

            return RedirectToAction(nameof(Details), new { id = model.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if ((await placeService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            var house = await placeService.PlaceDetailsById(id);
            var model = new PlaceDetailsViewModel()
            {
                ImageUrl = house.ImageUrl,
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(string id, PlaceDetailsViewModel model)
        {
            if ((await placeService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            await placeService.Delete(id);

            return RedirectToAction(nameof(All));
        }
     

    }

}
