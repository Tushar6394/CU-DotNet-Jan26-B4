namespace StudentCourseManagementAPI.DTOs;

public class CourseDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int Credits { get; set; }
    public List<StudentSummaryDto> Students { get; set; } = new();
}

public class CreateCourseDto
{
    public string Title { get; set; } = string.Empty;
    public int Credits { get; set; }
}

public class UpdateCourseDto
{
    public string Title { get; set; } = string.Empty;
    public int Credits { get; set; }
}

public class CourseSummaryDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int Credits { get; set; }
}
