using FirstVersion.Abstractions;
using FirstVersion.Configurations;
using FirstVersion.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstVersion.Repositories;

public class EmployeeRepository(AppDbContext appDbContext) : IEmployeeRepository
{
    public async Task<List<Employee>?> GetEmployeesWithCompletedDealsByCompanyIdAsync(int companyId)
    {
        var company = await appDbContext
            .Companies.Where(c => c.Id == companyId)
            .Include(c => c.Employees)
            .ThenInclude(employee => employee.CompletedDeals)
            .FirstOrDefaultAsync();
        return company?.Employees;
    }

    public Task<Employee> UpdateEmployeeAsync(Employee employee)
    {
        var result = appDbContext.Employees.Update(employee);
        return Task.FromResult(result.Entity);
    }

    public async Task<Company?> GetCompanyByEmployeeIdAsync(int employeeId)
    {
        var employee = await appDbContext
            .Employees.Include(e => e.Company)
            .FirstOrDefaultAsync(employee => employee.Id == employeeId);
        return employee?.Company;
    }

    public async Task<Employee?> GetEmployeeWithCompletedDealsByIdAsync(int employeeId)
    {
        return await appDbContext
            .Employees.Include(employee => employee.CompletedDeals)
            .FirstOrDefaultAsync(employee => employee.Id == employeeId);
    }
}
