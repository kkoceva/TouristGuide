using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TouristGuide.Infrastructure.Data.Entities
{
    public class ParentPlace
    {
        public ParentPlace()
        {
            Places = new List<Place>();
        }
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public List<Place> Places { get; set; }
    }
}
