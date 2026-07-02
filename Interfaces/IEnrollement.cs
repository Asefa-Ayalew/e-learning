using ELearning.Api.DTOs;

namespace ELearning.Api.Interfaces;
public interface IEnrollmentService
{
    Task<List<EnrollmentResponseDto>> GetAllAsync();
    Task<EnrollmentResponseDto?> GetByIdAsync(int id);
    Task<EnrollmentResponseDto> CreateAsync(EnrollmentCreateDto dto);
    Task<EnrollmentResponseDto?> UpdateAsync(int id, EnrollmentUpdateDto dto);
    Task<bool> DeleteAsync(int id);
}