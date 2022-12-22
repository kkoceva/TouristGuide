using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristGuide.Infrastructure.Data.Entities
{
    public class Comment
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(500)]
        public string? Description { get; set; }
    }
}
