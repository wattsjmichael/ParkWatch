namespace ParkWatchApi.Models
{
    public class StatePark
    {
        public int StateParkId { get; set; }
        public string StateParkName { get; set; }
        public string StateParkCity { get; set; }
        public string StateParkState { get; set; }

        public int StateParkCampingSpots { get; set; }

        public bool? IsOpenState {get; set;}
        

        
    }
}