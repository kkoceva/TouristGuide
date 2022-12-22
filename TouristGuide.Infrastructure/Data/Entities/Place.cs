using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TouristGuide.Infrastructure.Data.Entities
{
    public class Place
    {
        public Place()
        {
            Comments = new List<Comment>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(500)]
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

        [ForeignKey(nameof(ParentPlaceId))]
        public ParentPlace ParentPlace { get; set; } = null!;
       
        public string PlaceLocation { get; set; }

        public string? UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser? User { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
