using FirstVersion.Models;

namespace FirstVersion.Abstractions;

public interface IEmployeeRepository
{
    public Task<List<Employee>?> GetEmployeesByCompanyIdAsync(int companyId);
    public Task UpdateEmployeeAsync(Employee employee);
    public Task<Company?> GetCompanyByEmployeeIdAsync(int employeeId);
    public Task<Employee?> GetEmployeeByIdAsync(int employeeId);
}
