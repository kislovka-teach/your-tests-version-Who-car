using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecondVersion.Entities;

namespace SecondVersion.Configurations.ModelConfigurations;

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.ToTable("teachers");

        builder
            .Property(teacher => teacher.Name)
            .HasMaxLength(64)
            .HasDefaultValue("None");

        builder
            .HasMany(teacher => teacher.CoursesPublished)
            .WithOne(course => course.Teacher)
            .HasForeignKey(course => course.TeacherId);
    }
}
