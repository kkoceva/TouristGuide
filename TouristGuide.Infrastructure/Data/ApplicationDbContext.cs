using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TouristGuide.Infrastructure.Data.Configuration;
using TouristGuide.Infrastructure.Data.Entities;

namespace TouristGuide.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Place> Places { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new PlaceConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new CountryConfiguration());
            builder.ApplyConfiguration(new ParentPlaceConfiguration());

            base.OnModelCreating(builder);
        }

       
    }
}