using ELearning.Api.Data;
using ELearning.Api.Features.Courses.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Api.Features.Courses.Commands.UpdateCourse;

public class UpdateCourseCommandHandler
    : IRequestHandler<UpdateCourseCommand, CourseResponseDto>
{
    private readonly ApplicationDbContext _context;
    public UpdateCourseCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CourseResponseDto> Handle(
        UpdateCourseCommand request,
        CancellationToken cancellationToken)
    {
        var course = await _context.Courses.FirstOrDefaultAsync(
            c => c.Id == request.Id,
            cancellationToken
        );
        if (course == null)
            return null;

        course.Title = request.Title;
        course.Description = request.Description;
        course.Price = request.Price;

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