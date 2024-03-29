﻿using Microsoft.EntityFrameworkCore;
using SecondVersion.Abstractions;
using SecondVersion.Configurations;
using SecondVersion.Entities;

namespace SecondVersion.Repositories;

public class CompanyRepository(AppDbContext appDbContext) : ICompanyRepository
{
    public async Task<List<Teacher>?> GetTeachersWithCoursesPublishedByCompanyIdAsync(int companyId)
    {
        var company = await appDbContext
            .Companies.Where(c => c.Id == companyId)
            .Include(c => c.Teachers)
                .ThenInclude(teacher => teacher.CoursesPublished)
            .FirstOrDefaultAsync();
        return company?.Teachers;
    }

    public async Task<Company?> GetCompanyByTeacherIdAsync(int teacherId)
    {
        var teacher = await appDbContext.Teachers
            .Include(t => t.Company)
            .FirstOrDefaultAsync(teacher => teacher.Id == teacherId);
        return teacher?.Company;
    }

    public Task<Teacher> UpdateTeacherAsync(Teacher teacher)
    {
        var result = appDbContext.Teachers.Update(teacher);
        return Task.FromResult(result.Entity);
    }
}