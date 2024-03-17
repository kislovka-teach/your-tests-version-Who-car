using FirstVersion.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FirstVersion.Configurations.ModelConfigurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("employees");

        builder
            .HasMany(employee => employee.CompletedDeals)
            .WithOne(car => car.Employee)
            .HasForeignKey(car => car.EmployeeId);
    }
}
