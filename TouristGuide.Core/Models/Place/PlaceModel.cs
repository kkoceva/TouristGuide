using TouristGuide.Core.Contracts;
using System.ComponentModel.DataAnnotations;

namespace TouristGuide.Core.Models.Place
{
    public class PlaceModel : IPlaceModel
    {
        public string Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(500, MinimumLength = 50)]
        public string Description { get; set; } = null!;

        [Required]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Display(Name = "Country")]
        public int CountryId { get; set; }

        public IEnumerable<PlaceCategoryModel> PlaceCategories { get; set; } = new List<PlaceCategoryModel>();
        public IEnumerable<PlaceCountryModel> PlaceCountries { get; set; } = new List<PlaceCountryModel>();
    }
}
