using FirstVersion.Models;

namespace FirstVersion.Abstractions;

public interface IEmployeeRepository
{
    public Task<List<Employee>?> GetEmployeesWithCompletedDealsByCompanyIdAsync(int companyId);
    public Task<Employee> UpdateEmployeeAsync(Employee employee);
    public Task<Company?> GetCompanyByEmployeeIdAsync(int employeeId);
    public Task<Employee?> GetEmployeeWithCompletedDealsByIdAsync(int employeeId);
}
