using ELearning.Api.Data;
using ELearning.Api.DTOs;
using ELearning.Api.Models;
using ELearning.Api.Query.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Api.Features.Lessons.Queries.GetLessons;

public class GetLessonsQueryHandler : IRequestHandler<GetLessonsQuery, CollectionResult<LessonResponseDto>>
{
    private readonly ApplicationDbContext _context;

    public GetLessonsQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<CollectionResult<LessonResponseDto>> Handle(
        GetLessonsQuery request,
        CancellationToken cancellationToken
    )
    {
        IQueryable<Lesson> query = _context.Lessons.AsNoTracking();
        query = CollectionQueryBuilder<Lesson>.Apply(query, request.request);

        var total = await query.CountAsync(cancellationToken);
        var items = await query.Select(c => new LessonResponseDto
        {
            Id = c.Id,
            Title = c.Title,
            Content = c.Content,
            CreatedAt = c.CreatedAt
        }).ToListAsync(cancellationToken);

        return new CollectionResult<LessonResponseDto>
        {
            Items = items,
            Total = total
        };
    }
}