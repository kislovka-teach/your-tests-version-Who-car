using Microsoft.EntityFrameworkCore;
using SecondVersion.Abstractions;
using SecondVersion.Configurations;
using SecondVersion.Entities;

namespace SecondVersion.Repositories;

public class StudentRepository(AppDbContext appDbContext) : IStudentRepository
{
    public async Task<Student?> GetStudentByIdAsync(int studentId)
    {
        return await appDbContext.Students.FirstOrDefaultAsync(student => student.Id == studentId);
    }

    public async Task UpdateStudentAsync(Student student)
    {
        appDbContext.Students.Update(student);
        await appDbContext.SaveChangesAsync();
    }
}