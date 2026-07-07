using ELearning.Api.DTOs;
using ELearning.Api.Query.Models;
namespace ELearning.Api.Interfaces;

public interface ILessonService
{
    Task<CollectionResult<LessonResponseDto>> GetAllAsync(CollectionQuery query);
    Task<LessonResponseDto> GetByIdAsync(int id);
    Task<List<LessonResponseDto>> SearchAsync(string query, int page, int pageSize);
    Task<LessonResponseDto> CreateAsync(LessonCreateDto dto);
    Task<LessonResponseDto?> UpdateAsync(int id, LessonUpdateDto dto);
    Task<bool> DeleteAsync(int id);
}