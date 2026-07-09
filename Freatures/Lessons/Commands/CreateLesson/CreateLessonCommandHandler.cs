using ELearning.Api.Data;
using ELearning.Api.Features.Lessons.DTOs;
using ELearning.Api.Models;
using MediatR;

namespace ELearning.Api.Features.Lessons.Commands.CreateLesson;

public class CreateLessonCommandHandler : IRequestHandler<CreateLessonCommand, LessonResponseDto?>
{
    private readonly ApplicationDbContext _context;
    public CreateLessonCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<LessonResponseDto?> Handle(
        CreateLessonCommand request,
        CancellationToken cancellationToken
    )
    {
        var course = await _context.Courses.FindAsync(
                [request.CourseId],
                cancellationToken);
        if (course == null)
        {
            throw new Exception($"Course {request.CourseId} was not found");
        }
        var lesson = new Lesson
        {
            Title = request.Title,
            Description = request.Description,
            Content = request.Content,
            CourseId = request.CourseId,
            CreatedAt = DateTime.UtcNow
        };
        _context.Add(lesson);
        await _context.SaveChangesAsync(cancellationToken);
        return new LessonResponseDto
        {
            Id = lesson.Id,
            Title = lesson.Title,
            Description = lesson.Description,
            Content = lesson.Content,
            CreatedAt = lesson.CreatedAt
        };
    }
}