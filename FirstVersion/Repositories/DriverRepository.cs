using FirstVersion.Abstractions;
using FirstVersion.Configurations;
using FirstVersion.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstVersion.Repositories;

public class DriverRepository(AppDbContext appDbContext) : IDriverRepository
{
    public async Task<Driver?> GetDriverWithCarsByIdAsync(int driverId)
    {
        return await appDbContext.Drivers.FirstOrDefaultAsync(driver => driver.Id == driverId);
    }

    public Task<Driver> UpdateDriverAsync(Driver driver)
    {
        var result = appDbContext.Drivers.Update(driver);
        return Task.FromResult(result.Entity);
    }
}