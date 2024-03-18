using FirstVersion.Abstractions;
using FirstVersion.Configurations;

namespace FirstVersion.Repositories;

public class UnitOfWork(AppDbContext appDbContext) : IUnitOfWork
{
    public async Task SaveChangesAsync()
    {
        await appDbContext.SaveChangesAsync();
    }
}