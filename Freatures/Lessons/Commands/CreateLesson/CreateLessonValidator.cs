using FluentValidation;

namespace ELearning.Api.Features.Lessons.Commands.CreateLesson;

public class CreateLessonValidator : AbstractValidator<CreateLessonCommand>
{
    public CreateLessonValidator()
    {
        RuleFor(x => x.Title)
        .NotEmpty()
        .WithMessage("Lesson title is required")
        .MaximumLength(100)
        .WithMessage("Lesson title can't exceed maximum of 100 characters");

        RuleFor(x => x.Description)
        .NotEmpty()
        .WithMessage("Lesson description is required")
        .MaximumLength(500)
        .WithMessage("Lesson description can't exceed maximum of 100 characters");

        RuleFor(x => x.Content)
        .NotEmpty()
        .WithMessage("Lesson content is required")
        .MaximumLength(10000)
        .WithMessage("Lesson content can't exceed maximum of 100 characters");
    }
}