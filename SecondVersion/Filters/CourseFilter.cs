namespace SecondVersion.Filters;

public class CourseFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var path = 
            context.HttpContext.Request.Path.Value!
            .Split("/")
            .SkipWhile(e => e != "course")
            .ToList();
        if (!path.Any() || int.TryParse(path[1], out var courseId))
            return await next(context);
        
        var courses = 
            context.HttpContext.User.Claims
                .FirstOrDefault(claim => claim.Type == "Courses Enrolled")?.Value;
        if (courses is null) 
            return new ValueTask<object>();
        
        var coursesId = courses.Split(", ");
        if (coursesId.Contains(courseId.ToString()))
            return await next(context);

        return new ValueTask<object>();
    }
}