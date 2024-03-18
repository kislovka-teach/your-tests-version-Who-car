using SecondVersion.Entities;

namespace SecondVersion.Abstractions;

public interface IStudentRepository
{
    public Task<Student?> GetStudentWithCoursesEnrolledByIdAsync(int studentId);
    public Task<Student> UpdateStudentAsync(Student student);
}
