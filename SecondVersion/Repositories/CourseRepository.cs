using Microsoft.EntityFrameworkCore;
using SecondVersion.Abstractions;
using SecondVersion.Configurations;
using SecondVersion.Entities;

namespace SecondVersion.Repositories;

public class CourseRepository(AppDbContext appDbContext) : ICourseRepository
{
    public async Task AddNewCourseAsync(Course course)
    {
        await appDbContext.Courses.AddAsync(course);
        await appDbContext.SaveChangesAsync();
    }

    public async Task<List<Course>?> GetAllCoursesAsync(Func<Course, bool>? predicate = null)
    {
        if (predicate is null)
            return await appDbContext.Courses.ToListAsync();
        return appDbContext.Courses.Where(predicate).ToList();
    }

    public async Task<Course?> GetCourseByIdAsync(int courseId)
    {
        return await appDbContext.Courses.FirstOrDefaultAsync(course => course.Id == courseId);
    }

    public async Task UpdateCourseAsync(Course course)
    {
        appDbContext.Courses.Update(course);
        await appDbContext.SaveChangesAsync();
    }

    public async Task InsertModuleAsync(Module module, int courseId, int index)
    {
       var course = await appDbContext.Courses.FirstOrDefaultAsync(course => course.Id == courseId);
       if (course is null)
           return; 
       course.Modules.Insert(index, module);
       await appDbContext.SaveChangesAsync();
    }
}