using Microsoft.EntityFrameworkCore;

namespace ParkWatchApi.Models
{
    public class ParkWatchApiContext : DbContext
    {
        public ParkWatchApiContext(DbContextOptions<ParkWatchApiContext> options)
            : base(options)
        {
        }

        public DbSet<StatePark> StateParks { get; set; }
    }
}