using FirstVersion.Models;

namespace FirstVersion.Abstractions;

public interface IUserService
{
    public Task<string> LoginAsync(LoginRequest loginRequest);
}