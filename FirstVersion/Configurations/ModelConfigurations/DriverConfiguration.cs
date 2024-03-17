using FirstVersion.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FirstVersion.Configurations.ModelConfigurations;

public class DriverConfiguration : IEntityTypeConfiguration<Driver>
{
    public void Configure(EntityTypeBuilder<Driver> builder)
    {
        builder.ToTable("drivers");
        
        builder
            .Property(driver => driver.Category)
            .IsRequired();
        builder
            .Property(driver => driver.DrivingLicenseReceiptDate)
            .IsRequired();
        builder
            .Property(driver => driver.City)
            .HasMaxLength(64)
            .HasDefaultValue("None");
        
        builder
            .HasMany(driver => driver.Cars)
            .WithOne(car => car.Driver)
            .HasForeignKey(car => car.DriverId);
    }
}