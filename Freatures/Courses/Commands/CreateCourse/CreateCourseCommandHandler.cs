using ELearning.Api.Data;
using ELearning.Api.Features.Courses.DTOs;
using ELearning.Api.Models;
using MediatR;

namespace ELearning.Api.Features.Courses.Commands.CreateCourse;

public class CreateCourseCommandHandler
    : IRequestHandler<CreateCourseCommand, CourseResponseDto>
{
    private readonly ApplicationDbContext _context;
    public CreateCourseCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CourseResponseDto> Handle(
        CreateCourseCommand request,
        CancellationToken cancellationToken)
    {
        var course = new Course
        {
            Title = request.Title,
            Description = request.Description,
            Price = request.Price,
            CreatedAt = DateTime.UtcNow
        };

        _context.Courses.Add(course);
        await _context.SaveChangesAsync(cancellationToken);

        return new CourseResponseDto
        {
            Id = course.Id,
            Title = course.Title,
            Description = course.Description,
            CreatedAt = course.CreatedAt
        };
    }
}