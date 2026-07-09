using ELearning.Api.DTOs;
using MediatR;

namespace ELearning.Api.Features.Lessons.Queries.GetLessonsById;

public record GetLessonsByIdQuery(int id) : IRequest<LessonResponseDto?>;