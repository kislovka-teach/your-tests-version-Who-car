using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SecondVersion.Configurations.ModelConfigurations;
using SecondVersion.Entities;

namespace SecondVersion.Configurations;

public class AppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Teacher> Teachers => Set<Teacher>();
    public DbSet<Company> Companies => Set<Company>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Module> Modules => Set<Module>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "Host=localhost;Port=5432;Database=second;Username=postgres;Password=ab9q0rui"
        );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new StudentConfiguration());
        modelBuilder.ApplyConfiguration(new TeacherConfiguration());
        modelBuilder.ApplyConfiguration(new CompanyConfiguration());
        modelBuilder.ApplyConfiguration(new CourseConfiguration());
        modelBuilder.ApplyConfiguration(new ModuleConfiguration());
        
        DataSeeding(modelBuilder);
    }

    private void DataSeeding(ModelBuilder modelBuilder)
    {
        var hasher = new PasswordHasher<User>();
        
        var companies = new List<Company>
        {
            new Company { Id = 1, Name = "A" },
            new Company { Id = 2, Name = "B" }
        };

        var students = new List<Student>
        {
            new Student
            {
                Id = 1,
                Login = "123",
                Password = "123",
                Name = "Student A"
            },
            new Student
            {
                Id = 2,
                Login = "1234",
                Password = "1234",
                Name = "Student B"
            },
            new Student
            {
                Id = 3,
                Login = "12345",
                Password = "12345",
                Name = "Student C"
            }
        };

        var teachers = new List<Teacher>
        {
            new Teacher
            {
                Id = 4,
                Login = "123456",
                Password = "123456",
                Name = "Teacher A",
                CompanyId = 1
            },
            new Teacher
            {
                Id = 5,
                Login = "1234567",
                Password = "1234567",
                Name = "Teacher B",
                CompanyId = 2
            }
        };

        foreach (var t in students)
            t.Password = hasher.HashPassword(t, t.Password);

        foreach (var t in teachers)
            t.Password = hasher.HashPassword(t, t.Password);

        modelBuilder.Entity<Student>().HasData(students);
        modelBuilder.Entity<Teacher>().HasData(teachers);
        modelBuilder.Entity<Company>().HasData(companies);
    }
}
