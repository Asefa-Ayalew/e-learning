namespace ELearning.Api.Models;

public class Lesson
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int CourseId { get; set; }
    public Course? Course { get; set; }
    public string? FileName { get; set; }
    public string? ContentType { get; set; }
    public long? FileSize { get; set; }
    public byte[]? FileData { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}