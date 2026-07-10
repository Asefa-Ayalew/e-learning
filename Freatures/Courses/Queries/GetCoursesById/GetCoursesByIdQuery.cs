using ELearning.Api.Features.Courses.DTOs;
using MediatR;

namespace ELearning.Api.Features.Courses.Queries.GetCoursesById;

public record GetCoursesByIdQuery(int id) : IRequest<CourseResponseDto>;