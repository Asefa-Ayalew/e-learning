using FluentValidation;

namespace ELearning.Api.Features.Lessons.Commands.UpdateLesson;

public class UpdateLessonValidator : AbstractValidator<UpdateLessonCommand>
{
    public UpdateLessonValidator()
    {
        RuleFor(x => x.CourseId)
        .GreaterThan(0)
        .WithMessage("CourseId must be greater than 0");

        RuleFor(x => x.Title)
        .NotEmpty()
        .WithMessage("Lesson title must not be empty")
        .MaximumLength(100)
        .WithMessage("Lesson title cannot exceed 100 characters");

        RuleFor(x => x.Description)
        .NotEmpty()
        .WithMessage("Lesson description must not be empty")
        .MaximumLength(100)
        .WithMessage("Lesson description cannot exceed 100 characters");

        RuleFor(x => x.Content)
        .NotEmpty()
        .WithMessage("Lesson content must not be empty")
        .MaximumLength(100)
        .WithMessage("Lesson content cannot exceed 100 characters");
    }
}