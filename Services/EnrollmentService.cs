using ELearning.Api.Data;
using ELearning.Api.DTOs;
using ELearning.Api.Interfaces;
using ELearning.Api.Models;
using Microsoft.EntityFrameworkCore;

public class EnrollmentService : IEnrollmentService
{
    private readonly ApplicationDbContext _context;
    public EnrollmentService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<EnrollmentResponseDto>> GetAllAsync()
    {
        return await _context.Enrollments
        .Include(e => e.User)
        .Include(e => e.Course)
        .Select(e => new EnrollmentResponseDto
        {
            Id = e.Id,
            UserId = e.UserId,
            UserName = e.User.FullName,
            CourseId = e.CourseId,
            CourseTitle = e.Course.Title,
            EnrolledAt = e.EnrolledAt
        }).ToListAsync();
    }
    public async Task<EnrollmentResponseDto?> GetByIdAsync(int id)
    {
        var enrollment = await _context.Enrollments
        .Include(e => e.User)
        .Include(e => e.Course)
        .FirstOrDefaultAsync(e => e.Id == id);
        if (enrollment == null) return null;

        return new EnrollmentResponseDto
        {
            Id = enrollment.Id,
            UserId = enrollment.UserId,
            CourseId = enrollment.CourseId,
            CourseTitle = enrollment.Course.Title,
            EnrolledAt = enrollment.EnrolledAt,
            UserName = enrollment.User.FullName
        };
    }
    public async Task<EnrollmentResponseDto> CreateAsync(EnrollmentCreateDto dto)
    {
        var user = await _context.Users.FindAsync(dto.UserId);

        if (user == null)
            throw new Exception("User Not Found");

        var course = await _context.Courses.FindAsync(dto.CourseId);

        if (course == null)
            throw new Exception("Course Not Found");

        var exists = await _context.Enrollments.AnyAsync(e =>
        e.UserId == dto.UserId && e.CourseId == dto.CourseId);

        if (exists)
            throw new Exception("Student already enrolled.");

        var enrollment = new Enrollment()
        {
            UserId = dto.UserId,
            CourseId = dto.CourseId,
            EnrolledAt = DateTime.UtcNow
        };
        _context.Enrollments.Add(enrollment);
        await _context.SaveChangesAsync();

        return new EnrollmentResponseDto
        {
            Id = enrollment.Id,
            UserId = enrollment.UserId,
            UserName = user.FullName,
            CourseId = enrollment.CourseId,
            CourseTitle = course.Title,
            EnrolledAt = enrollment.EnrolledAt
        };
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var enrollment = await _context.Enrollments.FindAsync(id);
        if (enrollment == null) return false;

        _context.Enrollments.Remove(enrollment);
        await _context.SaveChangesAsync();

        return true;
    }
}