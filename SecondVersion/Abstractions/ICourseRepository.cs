using SecondVersion.Entities;

namespace SecondVersion.Abstractions;

public interface ICourseRepository
{
    public Task<Course> AddNewCourseAsync(Course course);
    public Task<List<Course>?> GetAllCoursesAsync(Func<Course, bool>? predicate = null);
    public Task<Course?> GetCourseWithModulesByIdAsync(int courseId);
    public Task<Course> UpdateCourseAsync(Course course);
    public Task InsertModuleAsync(Module module, int courseId, int index);
}
