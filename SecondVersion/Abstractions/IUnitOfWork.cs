using SecondVersion.Configurations;

namespace SecondVersion.Abstractions;

public interface IUnitOfWork
{
    public Task SaveChangesAsync();
}