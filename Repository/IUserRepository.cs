using CarRentalSystemAPI.Models;

namespace CarRentalSystemAPI.Repository
{
    public interface IUserRepository
    {
        Task<User> AddUserAsync(User user);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByIdAsync(int id);
    }
}
