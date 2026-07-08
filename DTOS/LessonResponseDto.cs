namespace ELearning.Api.DTOs;

public class LessonResponseDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int CourseId { get; set; }
    public DateTime CreatedAt { get; set; }
}