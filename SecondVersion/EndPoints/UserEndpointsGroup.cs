using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SecondVersion.Abstractions;
using SecondVersion.Models;

namespace SecondVersion.EndPoints;

public static class UserEndpointsGroup
{
    public static void RegisterUserEndpointsGroup(this IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapPost(
            "/login",
            async ([FromServices] IUserService userService, [FromBody] LoginRequest loginRequest, HttpContext context) =>
            {
                try
                {
                    var user = await userService.LoginAsync(loginRequest);
                    await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user);
                    return Results.Ok();
                }
                catch (Exception e)
                {
                    return Results.BadRequest(e.Message);
                }
            }
        );

        routeBuilder.MapGet(
            "/company/teachers/salary",
            async ([FromServices] ICompanyService companyService, [FromQuery] int companyId) =>
            {
                try
                {
                    return Results.Ok(await companyService.CalculateSalaryAsync(companyId));
                }
                catch (Exception e)
                {
                    return Results.BadRequest(e);
                }
            }
        );
    }
}
