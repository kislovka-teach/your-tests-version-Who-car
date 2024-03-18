namespace SecondVersion.Entities;

public class Module
{
    public int Id { get; set; }
    public string Name { get; set; }
    public short Ordinal { get; set; } // порядковый номер курса
    public string ContentUrl { get; set; }
    public double Duration { get; set; } // длительность модуля

    public int CourseId { get; set; }
    public Course Course { get; set; }
}