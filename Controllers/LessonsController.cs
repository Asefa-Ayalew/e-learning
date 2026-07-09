using ELearning.Api.DTOs;
using ELearning.Api.Features.Lessons.Commands.CreateLesson;
using ELearning.Api.Features.Lessons.Commands.DeleteLesson;
using ELearning.Api.Features.Lessons.Commands.UpdateLesson;
using ELearning.Api.Features.Lessons.Queries.GetLessons;
using ELearning.Api.Features.Lessons.Queries.GetLessonsById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ELearning.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LessonsController : ControllerBase
{
    private readonly IMediator _mediator;
    public LessonsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] CollectionQuery request)
    {
        var result = await _mediator.Send(new GetLessonsQuery(request));
        return Ok(result);
    }
    [HttpGet("id")]
    public async Task<IActionResult> GetById(int id)
    {
        var lesson = await _mediator.Send(new GetLessonsByIdQuery(id));
        if (lesson == null)
            return NotFound();

        return Ok(lesson);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateLessonCommand command)
    {
        var created = await _mediator.Send(command);

        return Ok(created);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateLessonCommand command)
    {
        var result = await _mediator.Send(command with { Id = id });
        if (result == null)
            return NotFound();

        return Ok(result);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteLessonCommand(id));
        if (!result)
            return NotFound();

        return NoContent();
    }
}