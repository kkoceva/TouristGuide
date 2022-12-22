using TouristGuide.Core.Models.Place;

namespace TouristGuide.Areas.Admin.Models
{
    public class MyPlacesViewModel
    {
        public IEnumerable<PlaceServiceModel> AddedPlaces { get; set; }
            = new List<PlaceServiceModel>();
      
    }
}
