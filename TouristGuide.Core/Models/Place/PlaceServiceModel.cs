using TouristGuide.Core.Contracts;
using System.ComponentModel.DataAnnotations;

namespace TouristGuide.Core.Models.Place
{
    public class PlaceServiceModel : IPlaceModel
    {
        public int Id { get; init; }

        public string Title { get; init; } = null!;


        [Display(Name = "Image URL")]
        public string ImageUrl { get; init; } = null!;

        [Display(Name = "Description")]
        public string? Description { get; init; }
    }
}
