using ELearning.Api.DTOs;
namespace ELearning.Api.Interfaces;

public interface ILessonService
{
    Task<List<LessonResponseDto>> GetAllAsync();
    Task<LessonResponseDto> GetByIdAsync(int id);
    Task<LessonResponseDto> CreateAsync(LessonCreateDto dto);
    Task<bool> DeleteAsync(int id);
}