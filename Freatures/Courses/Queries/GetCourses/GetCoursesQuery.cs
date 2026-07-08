using ELearning.Api.DTOs;
using ELearning.Api.Query.Models;
using MediatR;

namespace ELearning.Api.Features.Courses.Queries.GetCourses;

public record GetCoursesQuery(CollectionQuery Request)
: IRequest<CollectionResult<CourseResponseDto>>;