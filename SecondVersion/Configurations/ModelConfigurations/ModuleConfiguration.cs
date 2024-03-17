using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecondVersion.Entities;

namespace SecondVersion.Configurations.ModelConfigurations;

public class ModuleConfiguration : IEntityTypeConfiguration<Module>
{
    public void Configure(EntityTypeBuilder<Module> builder)
    {
        builder.HasKey(module => module.Id);

        builder
            .Property(module => module.Name)
            .HasMaxLength(64)
            .HasDefaultValue("None");
        builder
            .Property(module => module.ContentUrl)
            .HasMaxLength(128)
            .HasDefaultValue("http://localhost:3000/");

        builder
            .HasOne(module => module.Course)
            .WithMany(course => course.Modules)
            .HasForeignKey(module => module.CourseId);
    }
}