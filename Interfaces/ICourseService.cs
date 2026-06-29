using ELearning.Api.DTOs;

namespace ELearning.Api.Interfaces;

public interface ICourseService
{
    Task<List<CourseResponseDto>> GetAllAsync();

    Task<CourseResponseDto?> GetByIdAsync(int id);

    Task<CourseResponseDto> CreateAsync(CourseCreateDto dto);

    Task<bool> DeleteAsync(int id);
}