namespace ParkWatchApi.Models
{
    public class NatlPark
    {
        public int NatlParkId { get; set; }
        public string NatlParkName { get; set; }
        public string NatlParkCity { get; set; }
        public string NatlParkState { get; set; }

        public int NatlParkCampingSpots { get; set; }

        public bool IsOpenNatl {get; set; }
        
        
    }
}