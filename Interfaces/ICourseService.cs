using ELearning.Api.DTOs;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ELearning.Api.Interfaces;

public interface ICourseService
{
    Task<List<CourseResponseDto>> GetAllAsync();

    Task<CourseResponseDto?> GetByIdAsync(int id);
    Task<List<CourseResponseDto>> SearchAsync(string query, int page, int pageSize);
    Task<CourseResponseDto> CreateAsync(CourseCreateDto dto);

    Task<bool> DeleteAsync(int id);
}