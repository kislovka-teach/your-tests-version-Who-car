using FirstVersion.Models;

namespace FirstVersion.Abstractions;

public interface ICarService
{
    public Task AddNewCarAsync(AddCarRequest carRequest, int companyId);
    public Task<List<Car>?> GetAvailableCarsAsync();
    public Task<List<Car>?> GetAvailableCarsByCategoryAndCityAsync(Category category, string? city);
    public Task BookCarAsync(int carId, int driverId);
    public Task LeaseCarAsync(int carId, int employeeId);
    public Task ReturnCarAsync(int carId);
}