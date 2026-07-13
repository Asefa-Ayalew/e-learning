using AutoMapper;
using ELearning.Api.Data;
using ELearning.Api.Features.Courses.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Api.Features.Courses.Commands.UpdateCourse;

public class UpdateCourseCommandHandler
    : IRequestHandler<UpdateCourseCommand, CourseResponseDto>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public UpdateCourseCommandHandler(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
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

        _mapper.Map(request, course);

        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CourseResponseDto>(course);
    }
}