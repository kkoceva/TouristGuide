using TouristGuide.Core.Models.Place;

namespace TouristGuide.Core.Contracts
{
    public interface IPlaceService
    {
        Task<IEnumerable<PlaceCategoryModel>> AllCategories();

        Task<bool> CategoryExists(int categoryId);

        Task<string> Create(PlaceModel model);

        Task<PlaceQueryModel> All(
            string? category = null,
            string? searchTerm = null,
            PlaceSorting sorting = PlaceSorting.Newest,
            int currentPage = 1,
            int placesPerPage = 1);

        Task<IEnumerable<string>> AllCategoriesNames();

        Task<IEnumerable<PlaceServiceModel>> AllPlacesByUserId(string userId);

        Task<PlaceDetailsModel> PlaceDetailsById(string id);

        Task<bool> Exists(string id);

        Task Edit(string placeId, PlaceModel model);

        Task<int> GetPlaceCategoryId(string placeId);

        Task Delete(string placeId);
      
    }
}
