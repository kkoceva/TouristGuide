﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristGuide.Infrastructure.Data
{
    public class Category
    {
        public Category()
        {
            Places = new List<Place>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        public List<Place> Places { get; set; }
    }
}
