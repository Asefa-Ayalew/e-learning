using ELearning.Api.DTOs;
using ELearning.Api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ELearning.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CoursesController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] CollectionQuery query)
    {
        return Ok(await _courseService.GetAllAsync(query));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var course = await _courseService.GetByIdAsync(id);

        if (course == null)
            return NotFound();

        return Ok(course);
    }
    [HttpGet("search")]
    public async Task<IActionResult> Search(string query, int page, int pageSize)
    {
        var result = await _courseService.SearchAsync(query, page, pageSize);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CourseCreateDto dto)
    {
        var created = await _courseService.CreateAsync(dto);
        return Ok(created);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CourseUpdateDto dto)
    {
        var result = await _courseService.UpdateAsync(id, dto);
        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _courseService.DeleteAsync(id);

        if (!result)
            return NotFound();

        return NoContent();
    }
}