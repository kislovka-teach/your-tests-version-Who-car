using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecondVersion.Entities;

namespace SecondVersion.Configurations.ModelConfigurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasKey(company => company.Id);
        builder
            .Property(company => company.Name)
            .HasMaxLength(64)
            .HasDefaultValue("None");
        builder
            .Property(company => company.AvatarUrl)
            .HasMaxLength(128)
            .HasDefaultValue("https://buzookod.ru/media/2816616767_vubrbeJ.jpg");

        builder
            .HasMany(company => company.Teachers)
            .WithOne(teacher => teacher.Company)
            .HasForeignKey(teacher => teacher.CompanyId);
    }
}
