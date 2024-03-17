using SecondVersion.Entities;

namespace SecondVersion.Abstractions;

public interface IStudentRepository
{
    public Task<Student?> GetStudentByIdAsync(int studentId);
    public Task UpdateStudentAsync(Student student);
}