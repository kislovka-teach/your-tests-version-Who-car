using FirstVersion.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FirstVersion.Configurations.ModelConfigurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasKey(company => company.Id);
        
        builder
            .Property(company => company.Name)
            .HasMaxLength(64)
            .HasDefaultValue("Company name");
        
        builder
            .HasMany(company => company.Cars)
            .WithOne(car => car.Company)
            .HasForeignKey(car => car.CompanyId);
        builder
            .HasMany(company => company.Employees)
            .WithOne(employee => employee.Company)
            .HasForeignKey(employee => employee.CompanyId);
    }
}