using System.ComponentModel.DataAnnotations;

namespace CarRentalSystemAPI.Models
{
    public class RentalRequest
    {
        [Required]
        public int CarId { get; set; }

        [Required]
        public int UserId { get; set; }

        public DateTime RentalStartDate { get; set; }
        public DateTime RentalEndDate { get; set; }
    }
}
