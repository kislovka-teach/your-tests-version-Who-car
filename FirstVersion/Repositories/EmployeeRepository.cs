using FirstVersion.Abstractions;
using FirstVersion.Configurations;
using FirstVersion.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstVersion.Repositories;

public class EmployeeRepository(AppDbContext appDbContext) : IEmployeeRepository
{
    public async Task<List<Employee>?> GetEmployeesByCompanyIdAsync(int companyId)
    {
        var company = await appDbContext
            .Companies.Where(c => c.Id == companyId)
            .Include(c => c.Employees)
                .ThenInclude(employee => employee.CompletedDeals)
            .FirstOrDefaultAsync();
        return company?.Employees;
    }

    public async Task UpdateEmployeeAsync(Employee employee)
    {
        appDbContext.Employees.Update(employee);
        await appDbContext.SaveChangesAsync();
    }

    public async Task<Company?> GetCompanyByEmployeeIdAsync(int employeeId)
    {
        var employee = await appDbContext.Employees
            .Include(e => e.Company)
            .FirstOrDefaultAsync(employee => employee.Id == employeeId);
        return employee?.Company;
    }

    public async Task<Employee?> GetEmployeeByIdAsync(int employeeId)
    {
        return await appDbContext.Employees.FirstOrDefaultAsync(employee => employee.Id == employeeId);
    }
}
