using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using University.Api.Domain.Students.Requests;
using University.Application.Common;
using University.Application.Domain.Students.Commands.CreateStudent;
using University.Application.Domain.Students.Commands.DeleteStudent;
using University.Application.Domain.Students.Commands.UpdateStudent;
using University.Application.Domain.Students.Queries.GetStudentDetails;
using University.Application.Domain.Students.Queries.GetStudents;

namespace University.Api.Domain.Students;

[ApiController]
[Route("api/students")]
public class StudentsController(IMediator mediator) : Controller
{
    [HttpGet]
    [ProducesResponseType(typeof(PageResponse<GetStudentsDto[]>), 200)]
    public async Task<IActionResult> GetStudents(
        [FromQuery][Required] int pageSize = 1,
        [FromQuery][Required] int pageNumber = 10,
        CancellationToken cancellationToken = default)
    {
        var query = new GetStudentsQuery(pageSize, pageNumber);
        var students = await mediator.Send(query, cancellationToken);

        return Ok(students);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(StudentDetailsDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetStudentDetailsAsync(
        [FromRoute][Required] Guid id,
        CancellationToken cancellationToken = default)
    {
        var query = new GetStudentDetailsQuery(id);
        var bock = await mediator.Send(query, cancellationToken);
        return Ok(bock);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), 200)]
    public async Task<IActionResult> CreateStudent(
        [FromQuery][Required] CreateStudentRequest request,
        CancellationToken cancellationToken)
    {
        var command = new CreateStudentCommand(
            request.FirstName,
            request.LastName,
            request.MiddleName,
            request.PasportSerialNumber);

        var studentId = await mediator.Send(command, cancellationToken);

        return Ok(studentId);
    }

    [HttpPut]
    [ProducesResponseType(typeof(Guid), 200)]
    public async Task<IActionResult> UpdateStudent(
        [FromQuery][Required] UpdateStudentRequest request,
        CancellationToken cancellationToken)
    {
        _ = new UpdateStudentCommand(
            request.Id,
            request.FirstName,
            request.LastName,
            request.MiddleName,
            request.PasportSerialNumber);

        var studentId = await mediator.Send(typeof(Guid), cancellationToken);

        return Ok();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(Guid), 200)]
    public async Task<IActionResult> DeleteStudent(
        [FromQuery][Required] DeleteStudentRequest request,
        CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteStudentCommand(request.Id), cancellationToken);
        return Ok();
    }
}
