using SecondVersion.Entities;

namespace SecondVersion.Abstractions;

public interface ICompanyRepository
{
    public Task<List<Teacher>?> GetTeachersWithCoursesPublishedByCompanyIdAsync(int companyId);
    public Task<Company?> GetCompanyByTeacherIdAsync(int teacherId);
    public Task<Teacher> UpdateTeacherAsync(Teacher teacher);
}
