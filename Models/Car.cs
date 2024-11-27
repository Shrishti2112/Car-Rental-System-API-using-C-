using System.ComponentModel.DataAnnotations;

namespace CarRentalSystemAPI.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Range(1900, 2024)]
        public int Year { get; set; }

        [Range(0, double.MaxValue)]
        public decimal PricePerDay { get; set; }

        public bool IsAvailable { get; set; } = true;
    }

}
