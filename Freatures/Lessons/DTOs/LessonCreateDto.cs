namespace ELearning.Api.Features.Lessons.DTOs;

public class LessonCreateDto
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int CourseId { get; set; }
}