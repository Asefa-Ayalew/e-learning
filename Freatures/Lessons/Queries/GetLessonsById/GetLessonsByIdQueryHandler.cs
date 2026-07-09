using ELearning.Api.Data;
using ELearning.Api.Features.Lessons.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Api.Features.Lessons.Queries.GetLessonsById;

public class GetLessonsByIdQueryHandler :
IRequestHandler<GetLessonsByIdQuery, LessonResponseDto?>
{
    private readonly ApplicationDbContext _context;
    public GetLessonsByIdQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<LessonResponseDto?> Handle(
        GetLessonsByIdQuery request,
        CancellationToken cancellationToken
    )
    {
        return await _context.Lessons
        .AsNoTracking()
        .Where(l => l.Id == request.id)
        .Select(l => new LessonResponseDto
        {
            Id = l.Id,
            Content = l.Content,
            Title = l.Title,
            CourseId = l.CourseId,
            CreatedAt = l.CreatedAt
        }).FirstOrDefaultAsync(cancellationToken);
    }
}