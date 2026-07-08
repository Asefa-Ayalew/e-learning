using ELearning.Api.DTOs;
using ELearning.Api.Query.Models;

namespace ELearning.Api.Interfaces;

public interface IEnrollmentService
{
    Task<CollectionResult<EnrollmentResponseDto>> GetAllAsync(CollectionQuery query);
    Task<EnrollmentResponseDto?> GetByIdAsync(int id);
    Task<EnrollmentResponseDto> CreateAsync(EnrollmentCreateDto dto);
    Task<EnrollmentResponseDto?> UpdateAsync(int id, EnrollmentUpdateDto dto);
    Task<bool> DeleteAsync(int id);
}