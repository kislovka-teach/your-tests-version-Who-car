namespace SecondVersion.Entities;

public class Teacher : User
{
    public string Name { get; set; }
    public decimal Balance { get; set; }
    public List<Course> CoursesPublished { get; set; }

    public int CompanyId { get; set; }
    public Company Company { get; set; }

    public Teacher()
    {
        Role = Roles.Teacher;
    }
}
