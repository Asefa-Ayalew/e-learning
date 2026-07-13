using ELearning.Api.DTOs;
using ELearning.Api.Features.Lessons.DTOs;
using MediatR;

namespace ELearning.Api.Features.Lessons.Commands.CreateLesson;

public record CreateLessonCommand : IRequest<LessonResponseDto>
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int CourseId { get; set; }
    public IFormFile? File { get; set; }
};