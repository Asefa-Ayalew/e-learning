using ELearning.Api.Data;
using ELearning.Api.Features.Lessons.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Api.Features.Lessons.Commands.UpdateLesson;

public class UpdateLessonCommandHandler : IRequestHandler<UpdateLessonCommand, LessonResponseDto>
{
    private readonly ApplicationDbContext _context;
    public UpdateLessonCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<LessonResponseDto> Handle(
        UpdateLessonCommand request,
        CancellationToken cancellationToken
    )
    {
        var lesson = await _context.Lessons.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
        if (lesson == null)
            return null;

        lesson.Title = request.Title;
        lesson.Description = request.Description;
        lesson.Content = request.Content;

        await _context.SaveChangesAsync(cancellationToken);
        return new LessonResponseDto
        {
            Id = lesson.Id,
            Title = lesson.Title,
            Description = lesson.Description,
            Content = lesson.Content
        };
    }
}