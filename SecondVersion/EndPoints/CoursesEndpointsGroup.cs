using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using SecondVersion.Abstractions;
using SecondVersion.Filters;
using SecondVersion.Models;

namespace SecondVersion.EndPoints;

public static class CoursesEndpointsGroup
{
    public static void RegisterCoursesEndpointsGroup(this IEndpointRouteBuilder routeBuilder)
    {
        var courses = routeBuilder.MapGroup("/cars");

        courses
            .MapPost(
                "/post",
                async (
                    [FromServices] ICourseService courseService,
                    [FromBody] AddCourseRequest courseRequest,
                    ClaimsPrincipal user
                ) =>
                {
                    var companyId = user.Claims.Single(claim => claim.Type == "Company ID").Value;
                    await courseService.AddNewCourseAsync(courseRequest, int.Parse(companyId));
                    return Results.Created();
                }
            )
            .RequireAuthorization("TeachersOnly");

        courses.MapGet(
            "/get/all",
            async (
                [FromServices] ICourseService courseService,
                [FromQuery] string? theme = null,
                [FromQuery] int? rating = null
            ) => Results.Ok(await courseService.GetAllCoursesAsync(theme, rating))
        );

        var course = courses
            .MapGroup("/{courseId}")
            .RequireAuthorization()
            .AddEndpointFilter<CourseFilter>();

        course.MapPost(
            "/enroll",
            async (
                [FromServices] ICourseService courseService,
                [FromRoute] int courseId,
                ClaimsPrincipal user
            ) =>
            {
                var studentId = user.Claims.Single(claim => claim.Type == "ID").Value;
                try
                {
                    await courseService.EnrollCourseAsync(courseId, int.Parse(studentId));
                    return Results.Ok();
                }
                catch (Exception e)
                {
                    return Results.BadRequest(e);
                }
            }
        );

        course.MapPost(
            "/vote",
            async (
                [FromServices] ICourseService courseService,
                [FromRoute] int courseId,
                [FromQuery] short rating,
                ClaimsPrincipal user
            ) =>
            {
                try
                {
                    await courseService.VoteAsync(courseId, rating);
                    return Results.Ok();
                }
                catch (Exception e)
                {
                    return Results.BadRequest(e);
                }
            }
        );

        var module = course.MapGroup("/module");

        module
            .MapPost(
                "/post",
                async (
                    [FromServices] ICourseService courseService,
                    [FromBody] AddModuleRequest moduleRequest,
                    ClaimsPrincipal user
                ) =>
                {
                    await courseService.AddNewModuleAsync(moduleRequest);
                    return Results.Created();
                }
            )
            .RequireAuthorization("TeachersOnly");

        module.MapGet(
            "/{moduleId}",
            async ([FromServices] ICourseService courseService, [FromRoute] int moduleId) =>
                Results.Ok(await courseService.GetModuleAsync(moduleId))
        );
    }
}
