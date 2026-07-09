using ELearning.Api.Data;
using ELearning.Api.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Api.Features.Lessons.Commands.DeleteLesson;

public class DeleteLessonCommandHandler : IRequestHandler<DeleteLessonCommand, bool>
{
    private readonly ApplicationDbContext _context;
    public DeleteLessonCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(
        DeleteLessonCommand request,
        CancellationToken cancellationToken
    )
    {
        var lesson = await _context.Lessons.FirstOrDefaultAsync(
            c => c.Id == request.id,
            cancellationToken
        );
        if (lesson == null)
            return false;

        _context.Lessons.Remove(lesson);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

}