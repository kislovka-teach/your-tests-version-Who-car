using Microsoft.EntityFrameworkCore;
using SecondVersion.Abstractions;
using SecondVersion.Configurations;
using SecondVersion.Entities;

namespace SecondVersion.Repositories;

public class UserRepository(AppDbContext appDbContext) : IUserRepository
{
    public async Task<User?> GetUserByLoginAsync(string login)
    {
        return await appDbContext.Users.FirstOrDefaultAsync(user => user.Login == login);
    }
}