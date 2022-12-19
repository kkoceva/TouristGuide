namespace TouristGuide.Core.Models.Place
{
    public class PlaceQueryModel
    {
        public int TotalPlacesCount { get; set; }

        public IEnumerable<PlaceServiceModel> Places { get; set; } = new List<PlaceServiceModel>();
    }
}
