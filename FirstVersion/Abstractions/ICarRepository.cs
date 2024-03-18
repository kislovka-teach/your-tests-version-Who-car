using FirstVersion.Models;

namespace FirstVersion.Abstractions;

public interface ICarRepository
{
    public Task<Car> AddNewCarAsync(Car car);
    public Task<List<Car>?> GetAllCarsAsync(Func<Car, bool>? predicate = null);
    public Task<Car?> GetCarByIdAsync(int carId);
    public Task<Car> UpdateCarAsync(Car car);
}