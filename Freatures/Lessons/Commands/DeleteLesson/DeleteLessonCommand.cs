using MediatR;

namespace ELearning.Api.Features.Lessons.Commands.DeleteLesson;
public record DeleteLessonCommand(int id): IRequest<bool>;