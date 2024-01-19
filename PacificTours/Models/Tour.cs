using System.ComponentModel.DataAnnotations;

namespace PacificTours.Models
{
    public class Tour
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public int Cost { get; set; }
        [Required]
        public int Spaces { get; set; }
    }
}
