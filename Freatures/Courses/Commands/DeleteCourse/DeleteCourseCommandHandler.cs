using ELearning.Api.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Api.Features.Courses.Commands.DeleteCourse;

public class DeleteCourseCommandHandler
    : IRequestHandler<DeleteCourseCommand, bool>
{
    private readonly ApplicationDbContext _context;
    public DeleteCourseCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<bool> Handle(
        DeleteCourseCommand request,
        CancellationToken cancellationToken
    )
    {
        var course = await _context.Courses
        .FirstOrDefaultAsync(
            c => c.Id == request.id,
            cancellationToken
        );

        if (course == null)
            return false;
        _context.Courses.Remove(course);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}