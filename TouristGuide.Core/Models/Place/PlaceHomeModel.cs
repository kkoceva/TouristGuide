using TouristGuide.Core.Contracts;

namespace TouristGuide.Core.Models.Place
{
    public class PlaceHomeModel : IPlaceModel
    {
        public string Id { get; set; }

        public string Name { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string Description { get; init; } = null!;
    }
}
