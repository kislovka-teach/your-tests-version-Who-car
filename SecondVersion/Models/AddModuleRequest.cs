namespace SecondVersion.Models;

public class AddModuleRequest
{
    public string Name { get; set; }
    public string ContentUrl { get; set; }
    public int CourseId { get; set; }
    public short Ordinal { get; set; } = -1;
}