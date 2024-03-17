using SecondVersion.Entities;

namespace SecondVersion.Abstractions;

public interface ICompanyService
{
    public Task<Dictionary<Teacher, decimal>> CalculateSalaryAsync(int companyId);
}