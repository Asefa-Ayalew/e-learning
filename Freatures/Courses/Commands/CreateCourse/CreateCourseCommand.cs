using ELearning.Api.DTOs;
using MediatR;

namespace ELearning.Api.Features.Courses.Commands.CreateCourse;

public record CreateCourseCommand(
    string Title,
    string Description,
    decimal Price
) : IRequest<CourseResponseDto>;