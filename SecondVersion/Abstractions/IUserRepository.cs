using SecondVersion.Entities;

namespace SecondVersion.Abstractions;

public interface IUserRepository
{
    public Task<User?> GetUserByLoginAsync(string login);
}