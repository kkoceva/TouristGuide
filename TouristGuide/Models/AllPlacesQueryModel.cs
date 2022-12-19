using TouristGuide.Core.Models.Place;

namespace TouristGuide.Models
{
    public class AllPlacesQueryModel
    {
        public const int PlacesPerPage = 10;

        public string? Category { get; set; }

        public string? SearchTerm { get; set; }

        public PlaceSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalPlacesCount { get; set; }

        public IEnumerable<string> Categories { get; set; } = Enumerable.Empty<string>();

        public IEnumerable<PlaceServiceModel> Places { get; set; } = Enumerable.Empty<PlaceServiceModel>();
    }
}
