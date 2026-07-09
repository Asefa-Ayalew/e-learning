using ELearning.Api.Features.Courses.DTOs;
using MediatR;

namespace ELearning.Api.Features.Courses.Commands.CreateCourse;

public record CreateCourseCommand(
    string Title,
    string Description,
    decimal Price
) : IRequest<CourseResponseDto>;