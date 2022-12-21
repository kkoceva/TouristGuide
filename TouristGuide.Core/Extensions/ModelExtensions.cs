using TouristGuide.Core.Contracts;
using System.Text;
using System.Text.RegularExpressions;

namespace TouristGuide.Core.Extensions
{
    public static class ModelExtensions
    {
        public static string GetInformation(this IPlaceModel place)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(place.Name.Replace(" ", "-"));
            sb.Append("-");

            return sb.ToString();
        }
    }
}
