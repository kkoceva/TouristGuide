using TouristGuide.Core.Models.Statistics;

namespace TouristGuide.Core.Contracts
{
    public interface IStatisticsService
    {
        Task<StatisticsServiceModel> Total();
    }
}
