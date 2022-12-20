using TouristGuide.Core.Contracts;
using TouristGuide.Core.Exceptions;
using TouristGuide.Core.Models.Place;
using TouristGuide.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TouristGuide.Infrastructure.Data.Entities;

namespace TouristGuide.Core.Services
{
    public class PlaceService : IPlaceService
    {
        private readonly IRepository repo;

        private readonly IGuard guard;

        private readonly ILogger logger;

        public PlaceService(
            IRepository _repo,
            IGuard _guard,
            ILogger<PlaceService> _logger)
        {
            repo = _repo;
            guard = _guard;
            logger = _logger;
        }

        public async Task<PlaceQueryModel> All(string? category = null, string? searchTerm = null, PlaceSorting sorting = PlaceSorting.Newest, int currentPage = 1, int placesPerPage = 1)
        {
            var result = new PlaceQueryModel();
            var places = repo.AllReadonly<Place>();

            if (string.IsNullOrEmpty(category) == false)
            {
                places = places
                    .Where(h => h.Category.Name == category);
            }

            if (string.IsNullOrEmpty(searchTerm) == false)
            {
                searchTerm = $"%{searchTerm.ToLower()}%";

                places = places.Where(h => EF.Functions.Like(h.Title.ToLower(), searchTerm));
            }

            result.Places = await places
                .Skip((currentPage - 1) * placesPerPage)
                .Take(placesPerPage)
                .Select(p => new PlaceServiceModel() 
                {
                    Id = p.Id,
                    ImageUrl = p.ImageUrl,
                    Title = p.Title
                })
                .ToListAsync();

            result.TotalPlacesCount = await places.CountAsync();

            return result;
        }

        public async Task<IEnumerable<PlaceCategoryModel>> AllCategories()
        {
            return await repo.AllReadonly<Category>()
                .OrderBy(c => c.Name)
                .Select(c => new PlaceCategoryModel() 
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> AllCategoriesNames()
        {
            return await repo.AllReadonly<Category>()
                .Select(c => c.Name)
                .Distinct()
                .ToListAsync();
        }

        public async Task<IEnumerable<PlaceServiceModel>> AllPlacesByAgentId(int id)
        {
            return await repo.AllReadonly<Place>()
                .Select(c => new PlaceServiceModel() 
                {
                    Id = c.Id,
                    ImageUrl = c.ImageUrl,
                    Title = c.Title
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<PlaceServiceModel>> AllPlacesByUserId(string userId)
        {
            return await repo.AllReadonly<Place>()
                .Select(c => new PlaceServiceModel()
                {
                    Id = c.Id,
                    ImageUrl = c.ImageUrl,
                    Title = c.Title
                })
                .ToListAsync();
        }

        public async Task<bool> CategoryExists(int categoryId)
        {
            return await repo.AllReadonly<Category>()
                .AnyAsync(c => c.Id == categoryId);
        }

        public async Task<int> Create(PlaceModel model, int agentId)
        {
            var place = new Place()
            {
                CategoryId = model.CategoryId,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Title = model.Title,
            };

            try
            {
                await repo.AddAsync(place);
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(Create), ex);
                throw new ApplicationException("Database failed to save info", ex);
            }

            return place.Id;
        }

        public async Task Delete(int placeId)
        {
            var place = await repo.GetByIdAsync<Place>(placeId);
            await repo.SaveChangesAsync();
        }

        public async Task Edit(int placeId, PlaceModel model)
        {
            var place = await repo.GetByIdAsync<Place>(placeId);

            place.Description = model.Description;
            place.ImageUrl = model.ImageUrl;
            place.Title = model.Title;
            place.CategoryId = model.CategoryId;
            place.CountryId = model.CountryId;

            await repo.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await repo.AllReadonly<Place>()
                .AnyAsync(h => h.Id == id);
        }

        public async Task<int> GetPlaceCategoryId(int placeId)
        {
            return (await repo.GetByIdAsync<Place>(placeId)).CategoryId;
        }

       
        public async Task<PlaceDetailsModel> PlaceDetailsById(int id)
        {
            return await repo.AllReadonly<Place>()
                .Where(h => h.Id == id)
                .Select(h => new PlaceDetailsModel() 
                {
                    Category = h.Category.Name,
                    Description = h.Description,
                    Id = id,
                    ImageUrl = h.ImageUrl,
                    Title = h.Title,
                    
                })
                .FirstAsync();
        }

        public async Task<bool> IsRentedByUserWithId(int placeId, string currentUserId)
        {
            bool result = false;
            var place = await repo.AllReadonly<Place>()
                .Where(h => h.Id == placeId)
                .FirstOrDefaultAsync();

            return result;
        }


        public async Task Leave(int placeId)
        {
            var place = await repo.GetByIdAsync<Place>(placeId);
            guard.AgainstNull(place, "Place can not be found");

            await repo.SaveChangesAsync();
        }
      
        public async Task Rent(int placeId, string currentUserId)
        {
            var place = await repo.GetByIdAsync<Place>(placeId);

            guard.AgainstNull(place, "Place can not be found");

            await repo.SaveChangesAsync();
        }
    }
}
