using TouristGuide.Core.Models.Place;

namespace TouristGuide.Core.Contracts
{
    public interface IPlaceService
    {
        Task<IEnumerable<PlaceCategoryModel>> AllCategories();

        Task<bool> CategoryExists(int categoryId);

        Task<int> Create(PlaceModel model, int agentId);

        Task<PlaceQueryModel> All(
            string? category = null,
            string? searchTerm = null,
            PlaceSorting sorting = PlaceSorting.Newest,
            int currentPage = 1,
            int placesPerPage = 1);

        Task<IEnumerable<string>> AllCategoriesNames();

        Task<IEnumerable<PlaceServiceModel>> AllPlacesByUserId(string userId);

        Task<bool> Exists(int id);

        Task Edit(int placeId, PlaceModel model);

        Task<int> GetPlaceCategoryId(int placeId);

        Task Delete(int placeId);
      
    }
}
