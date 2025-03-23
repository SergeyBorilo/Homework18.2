using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using University.Api.Domain.Faculties.Requests;
using University.Application.Common;
using University.Application.Domain.Faculties.Commands.CreateFaculty;
using University.Application.Domain.Faculties.Commands.CreateFacultyDepartments;
using University.Application.Domain.Faculties.Commands.DeleteFaculty;
using University.Application.Domain.Faculties.Commands.DeleteFacultyDepartments;
using University.Application.Domain.Faculties.Queries.GetFaculties;
using University.Application.Domain.Faculties.Queries.GetFacultyDetails;

namespace University.Api.Domain.Faculties;

[Route("api/faculties")]
[ApiController]
public class FacultiesController(IMediator mediator) : Controller
{
    [HttpGet]
    [ProducesResponseType(typeof(PageResponse<FacultyDto[]>), 200)]
    public async Task<IActionResult> GetFaculties(
        [FromQuery][Required] int pageSize = 1,
        [FromQuery][Required] int pageNumber = 10,
        CancellationToken cancellationToken = default)
    {
        var query = new GetFacultyQuery(pageSize, pageNumber);
        var faculties = await mediator.Send(query, cancellationToken);

        return Ok(faculties);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(FacultyDetailsDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetDepartmentDetailsAsync(
        [FromRoute][Required] Guid id,
        CancellationToken cancellationToken = default)
    {
        var query = new GetFacultyDetailsQuery(id);
        var faculties = await mediator.Send(query, cancellationToken);
        return Ok(faculties);
    }


    [HttpPost]
    [ProducesResponseType(typeof(Guid), 200)]
    public async Task<IActionResult> CreateFaculty(
        [FromQuery][Required] CreateFacultyRequest request,
        CancellationToken cancellationToken)
    {
        var command = new CreateFacultyCommand(request.Name);

        var facultyId = await mediator.Send(command, cancellationToken);

        return Ok(facultyId);
    }

    [HttpPost("{id}/department")]
    [ProducesResponseType(typeof(Guid), 200)]
    public async Task CreateDepartments(
        [FromQuery][Required] CreateFacultyDepartmentsRequest request,
        CancellationToken cancellationToken)
    {
        var command = new CreateFacultyDepartmentsCommand(request.FacultyId, request.DepartmentId);

        await mediator.Send(command, cancellationToken);
    }



    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(Guid), 200)]
    public async Task<IActionResult> DeleteFaculty(
        [FromQuery][Required] DeleteFacultyRequest request,
        CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteFacultyCommand([request.Id]), cancellationToken);
        return Ok();
    }

    [HttpDelete("{id}/department")]
    [ProducesResponseType(typeof(Guid), 200)]
    public async Task<IActionResult> DeleteDepartments(
        [FromQuery][Required] DeleteFacultyDepartmentsRequest request,
        CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteFacultyDepartmentsCommand([request.FacultyId]), cancellationToken);
        return Ok();
    }
}
