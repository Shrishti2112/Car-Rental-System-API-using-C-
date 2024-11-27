using CarRentalSystemAPI.Models;

namespace CarRentalSystemAPI.Repository
{
    public interface ICarRepository
    {
        Task<Car> AddCarAsync(Car car);
        Task<Car> GetCarByIdAsync(int id);
        Task<List<Car>> GetAvailableCarsAsync();
        Task<Car> UpdateCarAvailabilityAsync(int carId, bool isAvailable);
        Task DeleteCarAsync(int carId);
    }
}
