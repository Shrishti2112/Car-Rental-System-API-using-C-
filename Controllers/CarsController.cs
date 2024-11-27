using CarRentalSystemAPI.Models;
using CarRentalSystemAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
    private readonly CarRentalService _carRentalService;
    private readonly ICarRepository _carRepository;

    public CarsController(CarRentalService carRentalService, ICarRepository carRepository)
    {
        _carRentalService = carRentalService;
        _carRepository = carRepository;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAvailableCars()
    {
        var cars = await _carRepository.GetAvailableCarsAsync();
        return Ok(cars);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddCar([FromBody] Car car)
    {
        var addedCar = await _carRepository.AddCarAsync(car);
        return CreatedAtAction(nameof(GetAvailableCars), new { id = addedCar.Id }, addedCar);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateCar(int id, [FromBody] Car car)
    {
        if (id != car.Id)
        {
            return BadRequest("Car ID mismatch");
        }

        await _carRepository.UpdateCarAvailabilityAsync(id, car.IsAvailable);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteCar(int id)
    {
        await _carRepository.DeleteCarAsync(id);
        return NoContent();
    }
}
