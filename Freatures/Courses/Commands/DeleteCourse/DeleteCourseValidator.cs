using FluentValidation;

namespace ELearning.Api.Features.Courses.Commands.DeleteCourse;

public class DeleteCourseValidator : AbstractValidator<DeleteCourseCommand>
{
    public DeleteCourseValidator()
    {
        RuleFor(x => x.id)
        .GreaterThan(0)
        .WithMessage("Course id must be greater than zero");

    }
}