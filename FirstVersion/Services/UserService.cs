using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FirstVersion.Abstractions;
using FirstVersion.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace FirstVersion.Services;

public class UserService(
    IConfiguration configuration,
    IUserRepository userRepository,
    IEmployeeRepository employeeRepository
) : IUserService
{
    public async Task<string> LoginAsync(LoginRequest loginRequest)
    {
        var user = await userRepository.GetUserByLoginAsync(loginRequest.Login);
        if (user is null)
            throw new Exception("No user with such login!");

        var hasher = new PasswordHasher<User>();
        var result = hasher.VerifyHashedPassword(user, user.Password, loginRequest.Password);

        if (result == PasswordVerificationResult.Failed)
            throw new Exception("Wrong password");

        var claims = new List<Claim>
        {
            new("ID", user.Id.ToString()),
            new(ClaimTypes.Name, user.Name),
            new(ClaimTypes.Role, user.Role.ToString())
        };
        if (user.Role == Role.Employee)
        {
            var company = await employeeRepository.GetCompanyByEmployeeIdAsync(user.Id);
            claims.Add(new Claim("Company", company.Name));
            claims.Add(new Claim("Company ID", company.Id.ToString()));
        }

        var jwt = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromDays(2)),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSecurityKey"])),
                SecurityAlgorithms.HmacSha256
            )
        );

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}
