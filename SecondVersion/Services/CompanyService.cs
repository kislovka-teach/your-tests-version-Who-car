using SecondVersion.Abstractions;
using SecondVersion.Entities;

namespace SecondVersion.Services;

public class CompanyService(ICompanyRepository companyRepository, IUnitOfWork unitOfWork) : ICompanyService
{
    public async Task<Dictionary<Teacher, decimal>> CalculateSalaryAsync(int companyId)
    {
        var teachers = await companyRepository.GetTeachersWithCoursesPublishedByCompanyIdAsync(companyId);
        if (teachers is null)
            throw new Exception($"No company with id {companyId}");

        var result = new Dictionary<Teacher, decimal>();
        foreach (var teacher in teachers)
        {
            var salary =
                1.000m
                + teacher.CoursesPublished.Sum(
                    course =>
                        (decimal)course.Modules.Sum(module => module.Duration)
                        / 160m
                        * course.StudentsEnrolled.Count
                );
            
            teacher.Balance = salary;
            await companyRepository.UpdateTeacherAsync(teacher);
            result.Add(teacher, salary);
        }

        await unitOfWork.SaveChangesAsync();

        return result;
    }
}
