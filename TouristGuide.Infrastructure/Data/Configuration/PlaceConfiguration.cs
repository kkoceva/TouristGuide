using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TouristGuide.Infrastructure.Data.Entities;

namespace TouristGuide.Infrastructure.Data.Configuration
{
    internal class PlaceConfiguration : IEntityTypeConfiguration<Place>
    {
        public void Configure(EntityTypeBuilder<Place> builder)
        {
            //builder.HasData(CreateHouses());
        }

        private List<Place> CreatePlaces()
        {
            var places = new List<Place>()
            {
                new Place()
                 {
                      Id = "1",
                      Name = "AifelTower",
                      Description = "A big tower.",
                      ImageUrl = "https://images.unsplash.com/photo-1502602898657-3e91760cbb34?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1173&q=80",
                      CategoryId = 3,
                     
                 },

                new Place()
                {
                    Id = "2",
                    Name = "Big Ben",
                    Description = "Nice to be seen in july",
                    ImageUrl = "https://images.pexels.com/photos/77171/pexels-photo-77171.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                    CategoryId = 2,
                },

                new Place()
                {
                    Id = "3",
                    Name = "Opera in sidney",
                    Description = "Nice view",
                    ImageUrl = "https://images.pexels.com/photos/1878293/pexels-photo-1878293.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                    CategoryId = 2,
                }
            };

            return places;
        }
    }
}
