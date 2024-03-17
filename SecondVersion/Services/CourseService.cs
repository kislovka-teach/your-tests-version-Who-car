using SecondVersion.Abstractions;
using SecondVersion.Entities;
using SecondVersion.Models;

namespace SecondVersion.Services;

public class CourseService(ICourseRepository courseRepository, IModuleRepository moduleRepository, IStudentRepository studentRepository) : ICourseService
{
    public async Task AddNewCourseAsync(AddCourseRequest courseRequest, int teacherId)
    {
        var course = new Course
        {
            Name = courseRequest.Name,
            Theme = courseRequest.Theme,
            Description = courseRequest.Description,
            TeacherId = teacherId
        };

        if (courseRequest.Modules is not null)
            course.Modules = courseRequest.Modules;

        await courseRepository.AddNewCourseAsync(course);
    }

    public async Task AddNewModuleAsync(AddModuleRequest moduleRequest)
    {
        var module = new Module
        {
            Name = moduleRequest.Name,
            ContentUrl = moduleRequest.ContentUrl,
            CourseId = moduleRequest.CourseId
        };
        
        if (moduleRequest.Ordinal == -1)
            await moduleRepository.AddNewModuleAsync(module);

        module.Ordinal = moduleRequest.Ordinal;
        await courseRepository.InsertModuleAsync(module, moduleRequest.CourseId, moduleRequest.Ordinal);
    }

    public async Task<List<Course>?> GetAllCoursesAsync(string? theme = null, double? rating = null)
    {
        if (theme is null && rating is null)
            return await courseRepository.GetAllCoursesAsync();
        else if (rating is null)
            return await courseRepository.GetAllCoursesAsync(course => course.Theme == theme);
        else
            return await courseRepository.GetAllCoursesAsync(course => course.Theme == theme && course.Rating >= rating);
    }

    public async Task<GetModuleContentResponse?> GetModuleAsync(int moduleId)
    {
        var module = await moduleRepository.GetModuleByIdAsync(moduleId);
        if (module is null)
            throw new Exception($"No registered module with id {moduleId}");
        return new GetModuleContentResponse { ContentUrl = module.ContentUrl };
    }

    public async Task EnrollCourseAsync(int courseId, int studentId)
    {
        var course = await courseRepository.GetCourseByIdAsync(courseId);
        if (course is null)
            throw new Exception($"No registered course with id {courseId}");
        
        var student = await studentRepository.GetStudentByIdAsync(studentId);
        if (student is null)
            throw new Exception($"No registered student with id {studentId}");
        
        course.StudentsEnrolled.Add(student);
        await courseRepository.UpdateCourseAsync(course);
        student.CoursesEnrolled.Add(course);
        await studentRepository.UpdateStudentAsync(student);
    }

    public async Task VoteAsync(int courseId, short score)
    {
        var course = await courseRepository.GetCourseByIdAsync(courseId);
        if (course is null)
            throw new Exception($"No registered course with id {courseId}");

        course.Rating = (course.Rating + score) / course.StudentsEnrolled.Count;
        await courseRepository.UpdateCourseAsync(course);
    }
}