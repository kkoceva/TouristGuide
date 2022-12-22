using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TouristGuide.Infrastructure.Data.Entities;

namespace TouristGuide.Infrastructure.Data.Configuration
{
    internal class ParentPlaceConfiguration : IEntityTypeConfiguration<ParentPlace>
    {
        public void Configure(EntityTypeBuilder<ParentPlace> builder)
        {
            builder.HasData(CreateParentPlaces());
        }

        private List<ParentPlace> CreateParentPlaces()
        {
            List<ParentPlace> parentPlaces = new List<ParentPlace>()
            {
                new ParentPlace()
                {
                    Id = 1,
                    Name = "Paris"
                },

                new ParentPlace()
                {
                    Id = 2,
                    Name = "London"
                },

                new ParentPlace()
                {
                    Id = 3,
                    Name = "Restaurant"
                }

             };

            return parentPlaces;
        }
    }
}
