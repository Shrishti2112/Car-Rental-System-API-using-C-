using System.ComponentModel.DataAnnotations;

namespace CarRentalSystemAPI.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public UserRole Role { get; set; } = UserRole.User;
    }
    public enum UserRole
    {
        User,
        Admin
    }
}
