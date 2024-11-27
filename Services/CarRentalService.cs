using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CarRentalSystemAPI.Models;
using CarRentalSystemAPI.Repository;
using Microsoft.IdentityModel.Tokens;

public class CarRentalService
{
    private readonly ICarRepository _carRepository;

    public CarRentalService(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task<RentalRequest> RentCarAsync(RentalRequest rentalRequest)
    {
        var car = await _carRepository.GetCarByIdAsync(rentalRequest.CarId);

        if (car == null || !car.IsAvailable)
        {
            throw new Exception("Car not available for rental");
        }

        // Update car availability
        await _carRepository.UpdateCarAvailabilityAsync(car.Id, false);

        return rentalRequest;
    }

    public async Task<bool> CheckCarAvailabilityAsync(int carId)
    {
        var car = await _carRepository.GetCarByIdAsync(carId);
        return car?.IsAvailable ?? false;
    }
}