namespace SecondVersion.Entities;

public class Student : User
{
    public string Name { get; set; }
    public List<Course> CoursesEnrolled { get; set; }

    public Student()
    {
        Role = Role.Student;
    }
}