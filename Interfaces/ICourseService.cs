using ELearning.Api.DTOs;
using ELearning.Api.Query.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ELearning.Api.Interfaces;

public interface ICourseService
{
    Task<Collection<CourseResponseDto>> GetAllAsync(CollectionQuery query);

    Task<CourseResponseDto?> GetByIdAsync(int id);
    Task<List<CourseResponseDto>> SearchAsync(string query, int page, int pageSize);
    Task<CourseResponseDto> CreateAsync(CourseCreateDto dto);

    Task<bool> DeleteAsync(int id);
}