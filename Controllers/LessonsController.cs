using ELearning.Api.DTOs;
using ELearning.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ELearning.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LessonsController : ControllerBase
{
    private readonly ILessonService _lessonService;

    public LessonsController(ILessonService lessonService)
    {
        _lessonService = lessonService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _lessonService.GetAllAsync());
    }
    [HttpGet("id")]
    public async Task<IActionResult> GetById(int id)
    {
        var lesson = await _lessonService.GetByIdAsync(id);
        if (lesson == null)
            return NotFound();

        return Ok(lesson);
    }

    [HttpPost]
    public async Task<IActionResult> Create(LessonCreateDto dto)
    {
        var created = await _lessonService.CreateAsync(dto);

        return Ok(created);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _lessonService.DeleteAsync(id);
        if (!result)
            return NotFound();

        return NoContent();
    }
}