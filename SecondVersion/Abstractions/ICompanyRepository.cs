using SecondVersion.Entities;

namespace SecondVersion.Abstractions;

public interface ICompanyRepository
{
    public Task<List<Teacher>?> GetTeachersByCompanyIdAsync(int companyId);
    public Task<Company?> GetCompanyByTeacherIdAsync(int teacherId);
    public Task UpdateTeacherAsync(Teacher teacher);
}
