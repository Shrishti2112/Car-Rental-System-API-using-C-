using CarRentalSystemAPI.Data;  // Add this line
using CarRentalSystemAPI.Models; // Assuming this is where Car and User models are located
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalSystemAPI.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly CarRentalDbContext _context;

        public CarRepository(CarRentalDbContext context)
        {
            _context = context;
        }

        public async Task<Car> AddCarAsync(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<Car> GetCarByIdAsync(int id)
        {
            return await _context.Cars.FindAsync(id);
        }

        public async Task<List<Car>> GetAvailableCarsAsync()
        {
            return await _context.Cars.Where(c => c.IsAvailable).ToListAsync();
        }

        public async Task<Car> UpdateCarAvailabilityAsync(int carId, bool isAvailable)
        {
            var car = await GetCarByIdAsync(carId);
            if (car == null) return null;

            car.IsAvailable = isAvailable;
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task DeleteCarAsync(int carId)
        {
            var car = await GetCarByIdAsync(carId);
            if (car != null)
            {
                _context.Cars.Remove(car);
                await _context.SaveChangesAsync();
            }
        }
    }
}
