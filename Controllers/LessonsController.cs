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
    public async Task<IActionResult> GetAll([FromQuery] CollectionQuery query)
    {
        return Ok(await _lessonService.GetAllAsync(query));
    }
    [HttpGet("id")]
    public async Task<IActionResult> GetById(int id)
    {
        var lesson = await _lessonService.GetByIdAsync(id);
        if (lesson == null)
            return NotFound();

        return Ok(lesson);
    }
    [HttpGet("search")]
    public async Task<IActionResult> Search(string query, int page, int pageSize)
    {
        var result = await _lessonService.SearchAsync(query, page, pageSize);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(LessonCreateDto dto)
    {
        var created = await _lessonService.CreateAsync(dto);

        return Ok(created);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, LessonUpdateDto dto)
    {
        var result = await _lessonService.UpdateAsync(id, dto);
        if (result == null)
            return NotFound();

        return Ok(result);
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