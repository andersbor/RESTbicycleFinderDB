using Microsoft.EntityFrameworkCore;

namespace bicyclefinder.Models
{
    public class BicycleFinderContext : DbContext
    {
        public BicycleFinderContext(DbContextOptions<BicycleFinderContext> options)
            : base(options)
        { }

        public DbSet<Bicycle> Bicycles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}