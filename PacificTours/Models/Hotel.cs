using System.ComponentModel.DataAnnotations;

namespace PacificTours.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string BedType { get; set; }
        [Required]
        public int Cost { get; set; }
        [Required]
        public int Spaces { get; set; }
    }
}
