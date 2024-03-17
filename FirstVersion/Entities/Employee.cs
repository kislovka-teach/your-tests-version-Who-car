namespace FirstVersion.Models;

public class Employee : User
{
    public List<Car> CompletedDeals { get; set; }
    public decimal Balance { get; set; }
    
    public int CompanyId { get; set; }
    public Company Company { get; set; }
}