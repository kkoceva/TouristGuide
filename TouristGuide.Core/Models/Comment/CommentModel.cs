using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristGuide.Core.Models.Place;
using TouristGuide.Infrastructure.Data.Entities;

namespace TouristGuide.Core.Models.Comment
{
    public class CommentModel
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(450)]
        public string CommentText { get; set; }

        [Required]
        public DateTime DateOfComment { get; set; }

        [Required]
        public string SenderId { get; set; }

        [ForeignKey(nameof(SenderId))]
        public ApplicationUser Sender { get; set; }

        [Required]
        public string PlaceId { get; set; }

        [ForeignKey(nameof(PlaceId))]
        public PlaceModel Place { get; set; }
      
    }
}
