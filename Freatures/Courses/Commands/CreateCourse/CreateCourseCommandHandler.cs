using AutoMapper;
using ELearning.Api.Data;
using ELearning.Api.Features.Courses.DTOs;
using ELearning.Api.Models;
using MediatR;

namespace ELearning.Api.Features.Courses.Commands.CreateCourse;

public class CreateCourseCommandHandler
    : IRequestHandler<CreateCourseCommand, CourseResponseDto>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public CreateCourseCommandHandler(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CourseResponseDto> Handle(
        CreateCourseCommand request,
        CancellationToken cancellationToken)
    {
        var course = _mapper.Map<Course>(request);
        course.CreatedAt = DateTime.UtcNow;

        _context.Courses.Add(course);
        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CourseResponseDto>(course);
    }
}