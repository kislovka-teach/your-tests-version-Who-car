using System.Security.Claims;
using FirstVersion.Abstractions;
using FirstVersion.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstVersion.EndPoints;

public static class CarsEndpointsGroup
{
    public static void RegisterCarsEndpointsGroup(this IEndpointRouteBuilder routeBuilder)
    {
        var cars = routeBuilder.MapGroup("/cars");

        cars.MapPost(
                "/add",
                async (
                    [FromServices] ICarService carService,
                    [FromBody] AddCarRequest carRequest,
                    ClaimsPrincipal user
                ) =>
                {
                    var companyId = user.Claims.Single(claim => claim.Type == "Company ID").Value;
                    await carService.AddNewCarAsync(carRequest, int.Parse(companyId));
                    return Results.Created();
                }
            )
            .RequireAuthorization();

        cars.MapGet(
            "/get/all",
            async ([FromServices] ICarService carService) =>
                Results.Ok(await carService.GetAvailableCarsAsync())
        );

        cars.MapGet(
            "/get",
            async (
                [FromServices] ICarService carService,
                [FromQuery] Category category,
                [FromQuery] string? city
            ) =>
            {
                await carService.GetAvailableCarsByCategoryAndCityAsync(category, city);
            }
        );

        var car = cars.MapGroup("/{id}").RequireAuthorization();

        car.MapPost(
            "/book",
            async (
                [FromServices] ICarService carService,
                [FromRoute] int id,
                ClaimsPrincipal user
            ) =>
            {
                var driverId = user.Claims.Single(claim => claim.Type == "ID").Value;
                try
                {
                    await carService.BookCarAsync(id, int.Parse(driverId));
                    return Results.Ok();
                }
                catch (Exception e)
                {
                    return Results.BadRequest(e);
                }
            }
        );

        car.MapPost(
            "/lease",
            async (
                [FromServices] ICarService carService,
                [FromRoute] int id,
                ClaimsPrincipal user
            ) =>
            {
                var employeeId = user.Claims.Single(claim => claim.Type == "ID").Value;
                try
                {
                    await carService.LeaseCarAsync(id, int.Parse(employeeId));
                    return Results.Ok();
                }
                catch (Exception e)
                {
                    return Results.BadRequest(e);
                }
            }
        );

        car.MapPost(
            "/return",
            async (
                [FromServices] ICarService carService,
                [FromRoute] int id,
                ClaimsPrincipal user
            ) =>
            {
                try
                {
                    await carService.ReturnCarAsync(id);
                    return Results.Ok();
                }
                catch (Exception e)
                {
                    return Results.BadRequest(e);
                }
            }
        );
    }
}
