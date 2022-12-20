using TouristGuide.Core.Contracts;
using TouristGuide.Core.Models.Statistics;
using TouristGuide.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using TouristGuide.Infrastructure.Data.Entities;

namespace TouristGuide.Core.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IRepository repo;

        public StatisticsService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<StatisticsServiceModel> Total()
        {
            int totalPlaces = await repo.AllReadonly<Place>().CountAsync();
               
         

            return new StatisticsServiceModel()
            {
                TotalPlaces = totalPlaces,
            };
        }
    }
}
