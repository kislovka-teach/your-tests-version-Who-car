using FirstVersion.Models;

namespace FirstVersion.Abstractions;

public interface IDriverRepository
{
    public Task<Driver?> GetDriverWithCarsByIdAsync(int driverId);
    public Task<Driver> UpdateDriverAsync(Driver driver);
}