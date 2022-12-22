using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristGuide.Core.Models.Place
{
    public class PlaceDetailsModel : PlaceServiceModel
    {
        public string Category { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string PlaceLocation { get; set; } = null!;
    }
}
