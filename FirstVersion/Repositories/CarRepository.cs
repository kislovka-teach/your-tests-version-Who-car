using FirstVersion.Abstractions;
using FirstVersion.Configurations;
using FirstVersion.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstVersion.Repositories;

public class CarRepository(AppDbContext appDbContext) : ICarRepository
{
    public async Task AddNewCarAsync(Car car)
    {
        await appDbContext.Cars.AddAsync(car);
        await appDbContext.SaveChangesAsync();
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

    public async Task UpdateCarAsync(Car car)
    {
        appDbContext.Cars.Update(car);
        await appDbContext.SaveChangesAsync();
    }
}