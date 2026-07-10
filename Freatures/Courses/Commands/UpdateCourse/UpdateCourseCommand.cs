using ELearning.Api.Features.Courses.DTOs;
using MediatR;

namespace ELearning.Api.Features.Courses.Commands.UpdateCourse;

public record UpdateCourseCommand(
    int Id,
    string Title,
    string Description,
    string Content,
    decimal Price
)
: IRequest<CourseResponseDto>;