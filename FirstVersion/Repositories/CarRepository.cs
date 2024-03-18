using FirstVersion.Abstractions;
using FirstVersion.Configurations;
using FirstVersion.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstVersion.Repositories;

public class CarRepository(AppDbContext appDbContext) : ICarRepository
{
    public async Task<Car> AddNewCarAsync(Car car)
    {
        var result = await appDbContext.Cars.AddAsync(car);
        return result.Entity;
    }

    public async Task<List<Car>?> GetAllCarsAsync(Func<Car, bool>? predicate = null)
    {
        if (predicate is null)
            return await appDbContext.Cars.ToListAsync();
        return appDbContext.Cars.Where(predicate).ToList();
    }

    public async Task<Car?> GetCarByIdAsync(int carId)
    {
        return await appDbContext.Cars.FirstOrDefaultAsync(car => car.Id == carId);
    }

    public Task<Car> UpdateCarAsync(Car car)
    {
        var result = appDbContext.Cars.Update(car);
        return Task.FromResult(result.Entity);
    }
}
