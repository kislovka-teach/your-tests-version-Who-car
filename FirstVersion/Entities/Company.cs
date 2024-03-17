namespace FirstVersion.Models;

public class Company
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public List<Car> Cars { get; set; }
    public List<Employee> Employees { get; set; }
}