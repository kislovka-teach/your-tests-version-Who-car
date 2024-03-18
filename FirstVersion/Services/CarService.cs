using FirstVersion.Abstractions;
using FirstVersion.Models;

namespace FirstVersion.Services;

public class CarService(
    ICarRepository carRepository,
    IEmployeeRepository employeeRepository,
    IDriverRepository driverRepository,
    IUnitOfWork unitOfWork
) : ICarService
{
    public async Task AddNewCarAsync(AddCarRequest carRequest, int companyId)
    {
        var car = new Car
        {
            Category = carRequest.Category,
            Brand = carRequest.Brand,
            Model = carRequest.Model,
            City = carRequest.City,
            CostPerDay = carRequest.CostPerDay,
            CreationDate = carRequest.CreationDate,
            CompanyId = companyId,
            Status = CarStatus.Available
        };

        await carRepository.AddNewCarAsync(car);
        await unitOfWork.SaveChangesAsync();
    }

    public async Task<List<Car>?> GetAvailableCarsAsync()
    {
        return await carRepository.GetAllCarsAsync();
    }

    public async Task<List<Car>?> GetAvailableCarsByCategoryAndCityAsync(
        Category category,
        string? city = null
    )
    {
        return await carRepository.GetAllCarsAsync(
            car => car.Category == category && car.City == city
        );
    }

    public async Task BookCarAsync(int carId, int driverId)
    {
        var car = await carRepository.GetCarByIdAsync(carId);
        if (car is null)
            throw new Exception($"No registered car with id {carId}");

        var driver = await driverRepository.GetDriverWithCarsByIdAsync(driverId);
        if (car.Status == CarStatus.Booked && car.DriverId != driverId)
            throw new Exception("Car already booked");
        if (driver is null || driver.DrivingLicenseReceiptDate.Year < 2014)
            throw new Exception("Driving license verification failed");
        if (car.City != driver.City)
            throw new Exception("Driver and car are in different cities");

        driver.Cars.Add(car);
        car.Status = CarStatus.Booked;

        await carRepository.UpdateCarAsync(car);
        await driverRepository.UpdateDriverAsync(driver);
        await unitOfWork.SaveChangesAsync();
    }

    public async Task LeaseCarAsync(int carId, int employeeId)
    {
        var car = await carRepository.GetCarByIdAsync(carId);
        if (car is null)
            throw new Exception($"No registered car with id {carId}");

        var employee = await employeeRepository.GetEmployeeWithCompletedDealsByIdAsync(employeeId);
        if (employee is null)
            throw new Exception($"No registered employee with id {employeeId}");

        employee.CompletedDeals.Add(car);
        await employeeRepository.UpdateEmployeeAsync(employee);
        await unitOfWork.SaveChangesAsync();
    }

    public async Task ReturnCarAsync(int carId)
    {
        var car = await carRepository.GetCarByIdAsync(carId);
        if (car is null)
            throw new Exception($"No registered car with id {carId}");

        car.LastLeased = DateTime.Now;
        car.Status = CarStatus.Available;

        await carRepository.UpdateCarAsync(car);
        await unitOfWork.SaveChangesAsync();
    }
}
