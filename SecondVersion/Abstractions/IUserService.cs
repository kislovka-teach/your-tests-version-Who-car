using System.Security.Claims;
using SecondVersion.Models;

namespace SecondVersion.Abstractions;

public interface IUserService
{
    public Task<ClaimsPrincipal> LoginAsync(LoginRequest loginRequest);
}