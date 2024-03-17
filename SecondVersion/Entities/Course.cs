namespace SecondVersion.Entities;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Theme { get; set; }
    public double Rating { get; set; }
    public string Description { get; set; }
    public List<Module> Modules { get; set; }
    public List<Student> StudentsEnrolled { get; set; }

    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }
}
