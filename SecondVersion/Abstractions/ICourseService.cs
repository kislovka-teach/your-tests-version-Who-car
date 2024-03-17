using SecondVersion.Entities;
using SecondVersion.Models;

namespace SecondVersion.Abstractions;

public interface ICourseService
{
    public Task AddNewCourseAsync(AddCourseRequest courseRequest, int teacherId);
    public Task AddNewModuleAsync(AddModuleRequest moduleRequest);
    public Task<List<Course>?> GetAllCoursesAsync(string? theme, double? rating);
    public Task<GetModuleContentResponse?> GetModuleAsync(int moduleId);
    public Task EnrollCourseAsync(int courseId, int studentId);
    public Task VoteAsync(int courseId, short score);
}
