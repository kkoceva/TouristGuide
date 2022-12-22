using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TouristGuide.Infrastructure.Data.Entities;

namespace TouristGuide.Infrastructure.Data.Configuration
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(CreateCategories());
        }

        private List<Category> CreateCategories()
        {
            List<Category> categories = new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Name = "Landmark"
                },

                new Category()
                {
                    Id = 2,
                    Name = "SightSeeing"
                },

                new Category()
                {
                    Id = 3,
                    Name = "Restaurant"
                }

             };

            return categories;
        }
    }
}
