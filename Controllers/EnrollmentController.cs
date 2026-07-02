using ELearning.Api.DTOs;
using ELearning.Api.Interfaces;
using ELearning.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace ELearning.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EnrollmentController : ControllerBase
{
    private readonly IEnrollmentService _enrollmentService;
    public EnrollmentController(IEnrollmentService enrollmentService)
    {
        _enrollmentService = enrollmentService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var enrollments = await _enrollmentService.GetAllAsync();
        return Ok(enrollments);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var enrollment = await _enrollmentService.GetByIdAsync(id);
        if (enrollment == null)
            return NotFound();

        return Ok(enrollment);
    }
    [HttpPost]
    public async Task<IActionResult> Enroll(EnrollmentCreateDto dto)
    {
        var enrollment = await _enrollmentService.CreateAsync(dto);

        return CreatedAtAction(nameof(GetById), new { id = enrollment.Id }, enrollment);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, EnrollmentUpdateDto dto)
    {
        var updatedEnrollment = await _enrollmentService.UpdateAsync(id, dto);
        if (updatedEnrollment == null)
            return NotFound();
        return Ok(updatedEnrollment);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _enrollmentService.DeleteAsync(id);
        if (!result)
            return NotFound();

        return NoContent();

    }
}