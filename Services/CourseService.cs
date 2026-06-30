using ELearning.Api.Data;
using ELearning.Api.DTOs;
using ELearning.Api.Interfaces;
using ELearning.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Api.Services;

public class CourseService : ICourseService
{
    private readonly ApplicationDbContext _context;

    public CourseService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<CourseResponseDto>> GetAllAsync()
    {
        return await _context.Courses
            .Select(c => new CourseResponseDto
            {
                Id = c.Id,
                Title = c.Title,
                Description = c.Description,
                CreatedAt = c.CreatedAt
            })
            .ToListAsync();
    }

    public async Task<CourseResponseDto?> GetByIdAsync(int id)
    {
        var course = await _context.Courses.FindAsync(id);

        if (course == null) return null;

        return new CourseResponseDto
        {
            Id = course.Id,
            Title = course.Title,
            Description = course.Description,
            CreatedAt = course.CreatedAt
        };
    }
    public async Task<List<CourseResponseDto>> SearchAsync(string query, int page = 1, int pageSize = 10)
    {
        if (string.IsNullOrWhiteSpace(query))
            return new List<CourseResponseDto>();

        return await _context.Courses
        .Where(c =>
        EF.Functions.ILike(c.Title, $"%{query}%") ||
        EF.Functions.ILike(c.Description, $"%{query}%"))
        .Skip((page - 1) * pageSize)
        .Take(pageSize)
        .Select(c => new CourseResponseDto
        {
            Id = c.Id,
            Description = c.Description,
            CreatedAt = c.CreatedAt
        })
        .ToListAsync();
    }

    public async Task<CourseResponseDto> CreateAsync(CourseCreateDto dto)
    {
        var course = new Course
        {
            Title = dto.Title,
            Description = dto.Description
        };

        _context.Courses.Add(course);
        await _context.SaveChangesAsync();

        return new CourseResponseDto
        {
            Id = course.Id,
            Title = course.Title,
            Description = course.Description,
            CreatedAt = course.CreatedAt
        };
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var course = await _context.Courses.FindAsync(id);

        if (course == null) return false;

        _context.Courses.Remove(course);
        await _context.SaveChangesAsync();

        return true;
    }
}