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
    public DbSet<NatlPark> NatlParks { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<StatePark>()
      .HasData(
       new StatePark { StateParkId = 1, StateParkName = "Bellingham State Park", StateParkCity = "Bellingham", StateParkState = "Washington", StateParkCampingSpots = 15, IsOpenState = true },
       new StatePark { StateParkId = 2, StateParkName = "Cascadia Park", StateParkCity = "Vancouver", StateParkState = "Washington", StateParkCampingSpots = 4, IsOpenState = true },
       new StatePark { StateParkId = 3, StateParkName = "Seaside State Park", StateParkCity = "Seaside", StateParkState = "Oregon", StateParkCampingSpots = 0, IsOpenState = false },
       new StatePark { StateParkId = 4, StateParkName = "Mt Hood State Park", StateParkCity = "Governement Camp", StateParkState = "Oregon", StateParkCampingSpots = 6, IsOpenState = true },
       new StatePark { StateParkId = 1, StateParkName = "Bellingham State Park", StateParkCity = "Bellingham", StateParkState = "Washington", StateParkCampingSpots = 15, IsOpenState = true }
      );
      builder.Entity<NatlPark>()
      .HasData(
        new NatlPark { NatlParkId = 1, NatlParkName = "Yellowstone", NatlParkCity = "Yellowstone City", NatlParkState = "Wyoming", NatlParkCampingSpots = 200, IsOpenNatl = true },
        new NatlPark { NatlParkId = 2, NatlParkName = "Glacier", NatlParkCity = "Glacier City", NatlParkState = "Montana", NatlParkCampingSpots = 1200, IsOpenNatl = true },
        new NatlPark { NatlParkId = 3, NatlParkName = "Appalachia National Park", NatlParkCity = "Montiplier", NatlParkState = "Vermont", NatlParkCampingSpots = 25, IsOpenNatl = false },
        new NatlPark { NatlParkId = 4, NatlParkName = "Mt. Ranier National Park", NatlParkCity = "Sequim", NatlParkState = "Washington", NatlParkCampingSpots = 300, IsOpenNatl = true },
        new NatlPark { NatlParkId = 5, NatlParkName = "Cascade Rainforest", NatlParkCity = "Forks", NatlParkState = "Washington", NatlParkCampingSpots = 21, IsOpenNatl = false }
      );
    }
  }
}