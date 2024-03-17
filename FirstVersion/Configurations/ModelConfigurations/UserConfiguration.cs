using FirstVersion.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FirstVersion.Configurations.ModelConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(user => user.Id);
        builder.HasAlternateKey(user => user.Login);
        
        builder
            .Property(user => user.Password)
            .HasMaxLength(256);
        builder
            .Property(user => user.Name)
            .HasMaxLength(32)
            .HasDefaultValue("Name");
        builder
            .Property(user => user.Role)
            .IsRequired()
            .HasDefaultValue(Role.Driver);
    }
}