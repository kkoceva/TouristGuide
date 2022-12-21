using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TouristGuide.Infrastructure.Data.Entities;

namespace TouristGuide.Models
{
    public class AddPlaceViewModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(200)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        [Required]
        public int CountryId { get; set; }

        [ForeignKey(nameof(CountryId))]
        public Country Country { get; set; } = null!;

        [Required]
        public int ParentPlaceId { get; set; }

        [ForeignKey(nameof(CountryId))]
        public ParentPlace ParentPlace { get; set; } = null!;

        public int? PlaceLocationId { get; set; }

        [ForeignKey(nameof(CountryId))]
        public PlaceLocation PlaceLocation { get; set; }

        public string? UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser? User { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
