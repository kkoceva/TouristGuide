using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TouristGuide.Infrastructure.Data.Entities;

namespace TouristGuide.Infrastructure.Data.Configuration
{
    internal class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(CreateCountries());
        }

        private List<Country> CreateCountries()
        {
            List<Country> countries = new List<Country>()
            {
                new Country()
                {
                    Id = 1,
                    Name = "France"
                },

                new Country()
                {
                    Id = 2,
                    Name = "United Kingdom"
                },

                new Country()
                {
                    Id = 3,
                    Name = "Australia"
                }

             };

            return countries;
        }
    }
}
