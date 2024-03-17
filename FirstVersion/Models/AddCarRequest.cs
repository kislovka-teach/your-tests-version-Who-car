namespace FirstVersion.Models;

public class AddCarRequest
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public Category Category { get; set; }
    public decimal CostPerDay { get; set; }
    public string City { get; set; }
    public DateTime CreationDate { get; set; }
}