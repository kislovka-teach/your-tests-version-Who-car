using Microsoft.EntityFrameworkCore;
using SecondVersion.Abstractions;
using SecondVersion.Configurations;
using SecondVersion.Entities;

namespace SecondVersion.Repositories;

public class CourseRepository(AppDbContext appDbContext) : ICourseRepository
{
    public async Task<Course> AddNewCourseAsync(Course course)
    {
        var result = await appDbContext.Courses.AddAsync(course);
        return result.Entity;
    }

    public async Task<List<Course>?> GetAllCoursesAsync(Func<Course, bool>? predicate = null)
    {
        if (predicate is null)
            return await appDbContext.Courses.ToListAsync();
        return appDbContext.Courses.Where(predicate).ToList();
    }

    public async Task<Course?> GetCourseWithModulesByIdAsync(int courseId)
    {
        return await appDbContext
            .Courses.Include(course => course.Modules)
            .FirstOrDefaultAsync(course => course.Id == courseId);
    }

    public Task<Course> UpdateCourseAsync(Course course)
    {
        var result = appDbContext.Courses.Update(course);
        return Task.FromResult(result.Entity);
    }

    public async Task InsertModuleAsync(Module module, int courseId, int index)
    {
        var course = await appDbContext.Courses.Include(c => c.Modules).SingleAsync(
            course => course.Id == courseId
        );
        course.Modules.Insert(index, module);
    }
}
