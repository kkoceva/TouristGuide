using TouristGuide.Core.Contracts;

namespace TouristGuide.Core.Models.Place
{
    public class PlaceHomeModel : IPlaceModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string Description { get; init; } = null!;
    }
}
