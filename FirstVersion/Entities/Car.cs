namespace FirstVersion.Models;

public class Car
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public Category Category { get; set; }
    public CarStatus Status { get; set; }
    public decimal CostPerDay { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime LastLeased { get; set; }
    public string City { get; set; }
    
    public int CompanyId { get; set; }
    public Company Company { get; set; }
    
    public int DriverId { get; set; }
    public Driver Driver { get; set; }

    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
}