using System.ComponentModel.DataAnnotations;
namespace ParkWatchApi.Models
{
    public class NatlPark
    {
        public int NatlParkId { get; set; }
        [Required]
        public string NatlParkName { get; set; }
        [Required]
        public string NatlParkCity { get; set; }
        [Required]
        public string NatlParkState { get; set; }
        [Required]
        public int NatlParkCampingSpots { get; set; }
        [Required]
        public bool? IsOpenNatl {get; set; }
        
        
    }
}