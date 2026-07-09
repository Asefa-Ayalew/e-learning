using ELearning.Api.Features.Lessons.DTOs;
using ELearning.Api.Query.Models;
using MediatR;

namespace ELearning.Api.Features.Lessons.Queries.GetLessons;

public record GetLessonsQuery(CollectionQuery request)
: IRequest<CollectionResult<LessonResponseDto>>;