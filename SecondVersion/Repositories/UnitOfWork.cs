using SecondVersion.Abstractions;
using SecondVersion.Configurations;

namespace SecondVersion.Repositories;

public class UnitOfWork(AppDbContext appDbContext) : IUnitOfWork
{
    public async Task SaveChangesAsync()
    {
        await appDbContext.SaveChangesAsync();
    }
}