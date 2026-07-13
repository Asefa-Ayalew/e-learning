using AutoMapper;
using ELearning.Api.Data;
using ELearning.Api.Features.Lessons.DTOs;
using ELearning.Api.Models;
using MediatR;

namespace ELearning.Api.Features.Lessons.Commands.CreateLesson;

public class CreateLessonCommandHandler : IRequestHandler<CreateLessonCommand, LessonResponseDto?>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public CreateLessonCommandHandler(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<LessonResponseDto?> Handle(
        CreateLessonCommand request,
        CancellationToken cancellationToken
    )
    {
        var course = await _context.Courses.FindAsync(
                [request.CourseId],
                cancellationToken);
        if (course == null)
        {
            throw new Exception($"Course {request.CourseId} was not found");
        }
        var lesson = _mapper.Map<Lesson>(request);
        lesson.CreatedAt = DateTime.UtcNow;
        if (request.File != null)
        {
            using var memoryStream = new MemoryStream();
            await request.File.CopyToAsync(memoryStream, cancellationToken);
            lesson.FileName = request.File.FileName;
            lesson.ContentType = request.File.ContentType;
            lesson.FileSize = request.File.Length;
            lesson.FileData = memoryStream.ToArray();
        }

        _context.Add(lesson);
        await _context.SaveChangesAsync(cancellationToken);
        return _mapper.Map<LessonResponseDto>(lesson);
    }
}