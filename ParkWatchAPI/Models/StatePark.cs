using System.ComponentModel.DataAnnotations;
namespace ParkWatchApi.Models
{
    public class StatePark
    {
        public int StateParkId { get; set; }
        [Required]
        public string StateParkName { get; set; }
        [Required]
        public string StateParkCity { get; set; }
        [Required]
        public string StateParkState { get; set; }
        [Required]
        public int StateParkCampingSpots { get; set; }
        [Required]
        public bool? IsOpenState {get; set;}
        

        
    }
}