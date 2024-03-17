using FirstVersion.Abstractions;
using FirstVersion.Configurations;
using FirstVersion.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstVersion.Repositories;

public class UserRepository(AppDbContext appDbContext) : IUserRepository
{
    public async Task<User?> GetUserByLoginAsync(string login)
    {
        return await appDbContext.Users.FirstOrDefaultAsync(user => user.Login == login);
    }
}