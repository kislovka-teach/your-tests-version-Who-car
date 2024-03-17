using FirstVersion.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FirstVersion.Configurations.ModelConfigurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasKey(car => car.Id);
        
        builder
            .Property(car => car.Brand)
            .HasMaxLength(64)
            .HasDefaultValue("None");
        builder
            .Property(car => car.Model)
            .HasMaxLength(64)
            .HasDefaultValue("None");
        builder
            .Property(car => car.Category)
            .IsRequired()
            .HasDefaultValue(Category.A);
        builder
            .Property(car => car.Status)
            .IsRequired()
            .HasDefaultValue(CarStatus.Available);
        builder
            .Property(car => car.CostPerDay)
            .HasColumnType("decimal(18,2)");
        builder
            .Property(car => car.CreationDate)
            .IsRequired()
            .HasDefaultValue(new DateTime());
        builder
            .Property(car => car.LastLeased)
            .IsRequired()
            .HasDefaultValue(new DateTime());
        builder
            .Property(car => car.City)
            .HasMaxLength(64)
            .HasDefaultValue("None");
    }
}