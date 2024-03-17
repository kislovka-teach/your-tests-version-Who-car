using SecondVersion.Entities;

namespace SecondVersion.Models;

public class AddCourseRequest
{
    public string Name { get; set; }
    public string Theme { get; set; }
    public string Description { get; set; }
    public List<Module>? Modules { get; set; }
}