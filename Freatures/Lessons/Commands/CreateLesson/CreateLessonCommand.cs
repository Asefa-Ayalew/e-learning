using ELearning.Api.DTOs;
using ELearning.Api.Features.Lessons.DTOs;
using MediatR;

namespace ELearning.Api.Features.Lessons.Commands.CreateLesson;

public record CreateLessonCommand(
    string Title,
    string Description,
    string Content,
    int CourseId
) : IRequest<LessonResponseDto>;