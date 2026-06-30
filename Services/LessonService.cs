using ELearning.Api.Data;
using ELearning.Api.DTOs;
using ELearning.Api.Interfaces;
using ELearning.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Api.Services;

public class LessonService : ILessonService
{
    private readonly ApplicationDbContext _context;

    public LessonService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<LessonResponseDto>> GetAllAsync()
    {
        return await _context.Lessons
            .Select(l => new LessonResponseDto
            {
                Id = l.Id,
                Title = l.Title,
                Content = l.Content,
                CourseId = l.CourseId,
                CreatedAt = l.CreatedAt
            })
            .ToListAsync();
    }

    public async Task<LessonResponseDto?> GetByIdAsync(int id)
    {
        var lesson = await _context.Lessons.FindAsync(id);

        if (lesson == null) return null;

        return new LessonResponseDto
        {
            Id = lesson.Id,
            Title = lesson.Title,
            Content = lesson.Content,
            CourseId = lesson.CourseId,
            CreatedAt = lesson.CreatedAt
        };
    }

    public async Task<List<LessonResponseDto>> SearchAsync(string query, int page = 1, int pageSize = 10)
    {
        if (string.IsNullOrWhiteSpace(query))
            return new List<LessonResponseDto>();

        return await _context.Lessons
        .Where(c =>
        EF.Functions.ILike(c.Title, $"%{query}%") ||
        EF.Functions.ILike(c.Description, $"%{query}%"))
        .Skip((page - 1) * pageSize)
        .Take(pageSize)
        .Select(c => new LessonResponseDto
        {
            Id = c.Id,
            Title = c.Title,
            Content = c.Content
        })
        .ToListAsync();
    }
    public async Task<LessonResponseDto> CreateAsync(LessonCreateDto dto)
    {
        var lesson = new Lesson
        {
            Title = dto.Title,
            Content = dto.Content,
            CourseId = dto.CourseId
        };

        _context.Lessons.Add(lesson);
        await _context.SaveChangesAsync();

        return new LessonResponseDto
        {
            Id = lesson.Id,
            Title = lesson.Title,
            Content = lesson.Content,
            CourseId = lesson.CourseId,
            CreatedAt = lesson.CreatedAt
        };
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var lesson = await _context.Lessons.FindAsync(id);

        if (lesson == null) return false;

        _context.Lessons.Remove(lesson);
        await _context.SaveChangesAsync();

        return true;
    }
}