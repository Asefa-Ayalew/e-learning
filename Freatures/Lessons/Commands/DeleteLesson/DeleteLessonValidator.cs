using FluentValidation;

namespace ELearning.Api.Features.Lessons.Commands.DeleteLesson;

public class DeleteLessonValidator : AbstractValidator<DeleteLessonCommand>
{
    public DeleteLessonValidator()
    {
        RuleFor(x => x.id)
        .GreaterThan(0)
        .WithMessage("Lesson id must be greater than 0");
    }
}