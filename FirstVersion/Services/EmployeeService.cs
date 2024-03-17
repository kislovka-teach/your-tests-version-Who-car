using FirstVersion.Abstractions;
using FirstVersion.Models;

namespace FirstVersion.Services;

public class EmployeeService(IEmployeeRepository employeeRepository) : IEmployeeService
{
    public async Task<Dictionary<Employee, decimal>> CalculateSalaryAsync(int companyId)
    {
        var employees = await employeeRepository.GetEmployeesByCompanyIdAsync(companyId);
        if (employees is null)
            throw new Exception($"No company with id {companyId}");

        var result = new Dictionary<Employee, decimal>();
        foreach (var employee in employees)
        {
            var salary = 15.000m + employee.CompletedDeals.Sum(car => 0.1m * car.CostPerDay);
            employee.Balance = salary;
            await employeeRepository.UpdateEmployeeAsync(employee);
            result.Add(employee, salary);
        }

        return result;
    }
}
