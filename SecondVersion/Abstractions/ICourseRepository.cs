using SecondVersion.Entities;

namespace SecondVersion.Abstractions;

public interface ICourseRepository
{
    public Task AddNewCourseAsync(Course course);
    public Task<List<Course>?> GetAllCoursesAsync(Func<Course, bool>? predicate = null);
    public Task<Course?> GetCourseByIdAsync(int courseId);
    public Task UpdateCourseAsync(Course course);
    public Task InsertModuleAsync(Module module, int courseId, int index);
}