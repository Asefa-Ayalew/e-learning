using ELearning.Api.DTOs;
using MediatR;

namespace ELearning.Api.Features.Courses.Commands.UpdateCourse;

public record UpdateCourseCommand(
    int Id,
    string Title,
    string Description,
    decimal Price
)
: IRequest<CourseResponseDto>;