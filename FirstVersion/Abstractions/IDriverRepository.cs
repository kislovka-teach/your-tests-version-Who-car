using FirstVersion.Models;

namespace FirstVersion.Abstractions;

public interface IDriverRepository
{
    public Task<Driver?> GetDriverByIdAsync(int driverId);
}