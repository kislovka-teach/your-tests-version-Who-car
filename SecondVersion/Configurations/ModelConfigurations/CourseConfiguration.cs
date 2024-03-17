using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecondVersion.Entities;

namespace SecondVersion.Configurations.ModelConfigurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(course => course.Id);
        builder
            .Property(course => course.Name)
            .HasMaxLength(64)
            .HasDefaultValue("None")
            .IsRequired();
        builder
            .Property(course => course.Theme)
            .HasMaxLength(32)
            .HasDefaultValue("None");
        builder
            .Property(course => course.Description)
            .HasMaxLength(512)
            .HasDefaultValue("None");

        builder
            .HasOne(course => course.Teacher)
            .WithMany(teacher => teacher.CoursesPublished)
            .HasForeignKey(course => course.TeacherId);

        builder
            .HasMany(course => course.StudentsEnrolled)
            .WithMany(student => student.CoursesEnrolled);

        builder
            .HasMany(course => course.Modules)
            .WithOne(module => module.Course)
            .HasForeignKey(module => module.CourseId);
    }
}
