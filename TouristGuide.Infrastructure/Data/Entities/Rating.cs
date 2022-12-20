using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristGuide.Infrastructure.Data.Entities
{
    public class Rating
    {
        public Rating()
        {
            Places = new List<Place>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public int Star { get; set; }

        public List<Place> Places { get; set; }
    }
}
