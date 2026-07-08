using MediatR;

namespace ELearning.Api.Features.Courses.Commands.DeleteCourse;

public record DeleteCourseCommand(int id)
: IRequest<bool>;