using Microsoft.EntityFrameworkCore;
using SecondVersion.Abstractions;
using SecondVersion.Configurations;
using SecondVersion.Entities;

namespace SecondVersion.Repositories;

public class StudentRepository(AppDbContext appDbContext) : IStudentRepository
{
    public async Task<Student?> GetStudentWithCoursesEnrolledByIdAsync(int studentId)
    {
        return await appDbContext
            .Students.Include(student => student.CoursesEnrolled)
            .FirstOrDefaultAsync(student => student.Id == studentId);
    }

    public Task<Student> UpdateStudentAsync(Student student)
    {
        var result = appDbContext.Students.Update(student);
        return Task.FromResult(result.Entity);
    }
}
