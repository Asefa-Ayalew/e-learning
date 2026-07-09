using ELearning.Api.Features.Lessons.DTOs;
using MediatR;

namespace ELearning.Api.Features.Lessons.Commands.UpdateLesson;

public record UpdateLessonCommand
(
    int Id,
    string Title,
    string Description,
    string Content,
    int CourseId

) : IRequest<LessonResponseDto>;