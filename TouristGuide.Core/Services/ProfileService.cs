using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristGuide.Core.Models.Place;
using TouristGuide.Infrastructure.Data.Common;
using TouristGuide.Infrastructure.Data.Entities;

namespace TouristGuide.Core.Services
{
    public class ProfileService
    {

        private readonly IRepository repo;

        private readonly ILogger logger;

        public ProfileService(
            IRepository _repo,
            ILogger<PlaceService> _logger)
        {
            repo = _repo;
            logger = _logger;
        }

        //public async Task<IEnumerable<ProfileServiceModel>> GetProfileByUserId(string userId)
        //{
        //    return await repo.AllReadonly<Profile>()
        //        .Select(c => new PlaceServiceModel()
        //        {
        //            Id = c.Id,
        //            ImageUrl = c.ImageUrl,
        //            Name = c.Name
        //        })
        //        .ToListAsync();
        //}

      

        //public async Task<string> Create(PlaceModel model)
        //{
        //    var place = new Place()
        //    {
        //        CategoryId = model.CategoryId,
        //        Description = model.Description,
        //        ImageUrl = model.ImageUrl,
        //        Name = model.Name,
        //    };

        //    try
        //    {
        //        await repo.AddAsync(place);
        //        await repo.SaveChangesAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.LogError(nameof(Create), ex);
        //        throw new ApplicationException("Database failed to save info", ex);
        //    }

        //    return place.Id;
        //}

    }
}
