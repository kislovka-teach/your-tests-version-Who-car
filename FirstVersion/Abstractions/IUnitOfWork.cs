using FirstVersion.Configurations;

namespace FirstVersion.Abstractions;

public interface IUnitOfWork
{
    public Task SaveChangesAsync();
}