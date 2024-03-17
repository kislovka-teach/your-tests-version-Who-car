using FirstVersion.Configurations.ModelConfigurations;
using FirstVersion.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FirstVersion.Configurations;

public class AppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Driver> Drivers => Set<Driver>();

    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Company> Companies => Set<Company>();

    public DbSet<Car> Cars => Set<Car>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new DriverConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        modelBuilder.ApplyConfiguration(new CompanyConfiguration());
        modelBuilder.ApplyConfiguration(new CarConfiguration());

        DataSeeding(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "Host=localhost;Port=5432;Database=first;Username=postgres;Password=ab9q0rui"
        );
    }

    private void DataSeeding(ModelBuilder modelBuilder)
    {
        var hasher = new PasswordHasher<User>();
        
        var companies = new List<Company>
        {
            new Company { Id = 1, Name = "A" },
            new Company { Id = 2, Name = "B" }
        };

        var drivers = new List<Driver>
        {
            new Driver
            {
                Id = 1,
                Login = "123",
                Password = "123",
                Role = Role.Driver
            },
            new Driver
            {
                Id = 2,
                Login = "1234",
                Password = "1234",
                Role = Role.Driver
            },
            new Driver
            {
                Id = 3,
                Login = "12345",
                Password = "12345",
                Role = Role.Driver
            }
        };

        var employees = new List<Employee>
        {
            new Employee
            {
                Id = 4,
                Login = "123456",
                Password = "123456",
                Role = Role.Employee,
                CompanyId = 1
            },
            new Employee
            {
                Id = 5,
                Login = "1234567",
                Password = "1234567",
                Role = Role.Employee,
                CompanyId = 2
            }
        };

        foreach (var t in drivers)
            t.Password = hasher.HashPassword(t, t.Password);
        
        foreach (var t in employees)
            t.Password = hasher.HashPassword(t, t.Password);
        
        modelBuilder.Entity<Driver>().HasData(drivers);
        modelBuilder.Entity<Employee>().HasData(employees);
        modelBuilder.Entity<Company>().HasData(companies);
    }
}
