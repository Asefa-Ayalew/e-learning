using ELearning.Api.Data;
using ELearning.Api.DTOs;
using ELearning.Api.Models;
using ELearning.Api.Query.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Api.Features.Courses.Queries.GetCourses;

public class GetCoursesQueryHandler : IRequestHandler<GetCoursesQuery, CollectionResult<CourseResponseDto>>
{
    private readonly ApplicationDbContext _context;

    public GetCoursesQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CollectionResult<CourseResponseDto>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Course> query = _context.Courses.AsNoTracking();
        query = CollectionQueryBuilder<Course>.Apply(query, request.Request);

        var total = await query.CountAsync(cancellationToken);
        var items = await query.Select(c => new CourseResponseDto
        {
            Id = c.Id,
            Title = c.Title,
            Description = c.Description,
            CreatedAt = c.CreatedAt
        }).ToListAsync(cancellationToken);

        return new CollectionResult<CourseResponseDto>
        {
            Items = items,
            Total = total
        };
    }
}