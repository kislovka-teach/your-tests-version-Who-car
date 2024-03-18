using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using SecondVersion.Abstractions;
using SecondVersion.Entities;
using SecondVersion.Models;

namespace SecondVersion.Services;

public class UserService(IUserRepository userRepository, ICompanyRepository companyRepository) : IUserService
{
    public async Task<ClaimsPrincipal> LoginAsync(LoginRequest loginRequest)
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
            new(ClaimTypes.Role, user.Role.ToString())
        };
        if (user.Role == Roles.Teacher)
        {
            var company = await companyRepository.GetCompanyByTeacherIdAsync(user.Id);
            claims.Add(new Claim("Company ID", company.Id.ToString()));
        }

        var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
        return new ClaimsPrincipal(claimsIdentity);
    }
}