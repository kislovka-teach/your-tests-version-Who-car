using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecondVersion.Entities;

namespace SecondVersion.Configurations.ModelConfigurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("students");

        builder
            .Property(student => student.Name)
            .HasMaxLength(64)
            .HasDefaultValue("None");

        builder
            .HasMany(student => student.CoursesEnrolled)
            .WithMany(course => course.StudentsEnrolled);
    }
}