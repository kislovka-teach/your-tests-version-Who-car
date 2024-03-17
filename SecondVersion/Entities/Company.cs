namespace SecondVersion.Entities;

public class Company
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string AvatarUrl { get; set; }
    public List<Teacher> Teachers { get; set; }
}