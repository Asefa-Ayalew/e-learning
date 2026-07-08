using ELearning.Api.DTOs;
using MediatR;

namespace ELearning.Api.Features.Courses.Queries.GetCoursesById;

public record GetCoursesByIdQuery(int Id) : IRequest<CourseResponseDto?>;