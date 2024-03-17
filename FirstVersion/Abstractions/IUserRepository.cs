using FirstVersion.Models;

namespace FirstVersion.Abstractions;

public interface IUserRepository
{
    public Task<User?> GetUserByLoginAsync(string login);
}