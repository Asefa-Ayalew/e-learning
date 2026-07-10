using FluentValidation;

namespace ELearning.Api.Features.Courses.Commands.CreateCourse;

public class CreateCourseValidator : AbstractValidator<CreateCourseCommand>
{
    public CreateCourseValidator()
    {
        RuleFor(x => x.Title)
        .NotEmpty()
        .WithMessage("Course title is required.")
        .MaximumLength(100)
        .WithMessage("Course title cannot exceed 100 characters.");

        RuleFor(x => x.Description)
        .NotEmpty()
        .WithMessage("Course description is required.")
        .MaximumLength(500)
        .WithMessage("Course description can't exceed 500 characters.");
    }
}