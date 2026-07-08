using ELearning.Api.Data;
using ELearning.Api.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Api.Features.Courses.Queries.GetCoursesById;

public class GetCoursesByIdQueryHandler : IRequestHandler<GetCoursesByIdQuery, CourseResponseDto?>
{
    private readonly ApplicationDbContext _context;
    public GetCoursesByIdQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CourseResponseDto?> Handle(
        GetCoursesByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.Courses
        .AsNoTracking()
        .Where(c => c.Id == request.Id)
        .Select(c => new CourseResponseDto
        {
            Id = c.Id,
            Title = c.Title,
            Description = c.Description,
            CreatedAt = c.CreatedAt
        }).FirstOrDefaultAsync(cancellationToken);
    }
}