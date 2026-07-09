using ELearning.Api.Features.Courses.DTOs;
using ELearning.Api.Features.Courses.Commands.CreateCourse;
using ELearning.Api.Features.Courses.Commands.DeleteCourse;
using ELearning.Api.Features.Courses.Commands.UpdateCourse;
using ELearning.Api.Features.Courses.Queries.GetCourses;
using ELearning.Api.Features.Courses.Queries.GetCoursesById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ELearning.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CoursesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] CollectionQuery request)
    {
        var result = await _mediator.Send(new GetCoursesQuery(request));
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var course = await _mediator.Send(new GetCoursesByIdQuery(id));

        if (course == null)
            return NotFound();

        return Ok(course);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCourseCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateCourseCommand command)
    {
        var result = await _mediator.Send(command with { Id = id });
        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteCourseCommand(id));

        if (!result)
            return NotFound();

        return NoContent();
    }
}