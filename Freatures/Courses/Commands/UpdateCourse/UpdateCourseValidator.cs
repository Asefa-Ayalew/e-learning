using FluentValidation;

namespace ELearning.Api.Features.Courses.Commands.UpdateCourse;

public class UpdateCourseValidator : AbstractValidator<UpdateCourseCommand>
{
    public UpdateCourseValidator()
    {
        RuleFor(x => x.Id)
        .GreaterThan(0)
        .WithMessage("CourseId must be greater than 0");

        RuleFor(x => x.Title)
        .NotEmpty()
        .WithMessage("Course title is required")
        .MaximumLength(100)
        .WithMessage("Course title can't exceed 100 characters"); ;

        RuleFor(x => x.Description)
        .NotEmpty()
        .WithMessage("Course Description is required")
        .MaximumLength(500)
        .WithMessage("Course Description can't exceed 500 characters");

        RuleFor(x => x.Content)
        .NotEmpty()
        .WithMessage("Course Content is required")
        .MaximumLength(500)
        .WithMessage("Course Content can't exceed 500 characters");
    }
}