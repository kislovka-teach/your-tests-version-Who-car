using FirstVersion.Abstractions;
using FirstVersion.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstVersion.EndPoints;

public static class UserEndpointsGroup
{
    public static void RegisterUserEndpointsGroup(this IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapPost(
            "/login",
            async (
                [FromServices] IUserService userService,
                [FromBody] LoginRequest loginRequest,
                HttpContext context
            ) =>
            {
                try
                {
                    var token = await userService.LoginAsync(loginRequest);
                    return Results.Json(token);
                }
                catch (Exception e)
                {
                    return Results.BadRequest(e.Message);
                }
            }
        );

        routeBuilder.MapGet(
            "/employee/all/salary",
            async ([FromServices] IEmployeeService employeeService, [FromQuery] int companyId) =>
            {
                try
                {
                    return Results.Ok(await employeeService.CalculateSalaryAsync(companyId));
                }
                catch (Exception e)
                {
                    return Results.BadRequest(e);
                }
            }
        );
    }
}
