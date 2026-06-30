using ELearning.Api.DTOs;
namespace ELearning.Api.Interfaces;

public interface ILessonService
{
    Task<List<LessonResponseDto>> GetAllAsync();
    Task<LessonResponseDto> GetByIdAsync(int id);
    Task<List<LessonResponseDto>> SearchAsync(string query, int page, int pageSize);
    Task<LessonResponseDto> CreateAsync(LessonCreateDto dto);
    Task<bool> DeleteAsync(int id);
}