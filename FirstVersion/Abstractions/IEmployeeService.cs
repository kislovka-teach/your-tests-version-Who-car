using FirstVersion.Models;

namespace FirstVersion.Abstractions;

public interface IEmployeeService
{
    public Task<Dictionary<Employee, decimal>> CalculateSalaryAsync(int companyId);
}
