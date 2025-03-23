using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using University.Api.Domain.Departments.Requests;
using University.Application.Common;
using University.Application.Domain.Departments.Commands.CreateDepartment;
using University.Application.Domain.Departments.Commands.DeleteDepartment;
using University.Application.Domain.Departments.Queries.GetDepartmentDetails;
using University.Application.Domain.Departments.Queries.GetDepartments;

namespace University.Api.Domain.Departments;

[Route("api/departments")]
[ApiController]
public class DepartmentsController(IMediator mediator) : Controller
{
    [HttpGet]
    [ProducesResponseType(typeof(PageResponse<DepartmentDto[]>), 200)]
    public async Task<IActionResult> GetDepartments(
        [FromQuery][Required] int pageSize = 1,
        [FromQuery][Required] int pageNumber = 10,
        CancellationToken cancellationToken = default)
    {
        var query = new GetDepartmentQuery(pageSize, pageNumber);
        var departments = await mediator.Send(query, cancellationToken);

        return Ok(departments);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(DepartmentDetailsDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetDepartmentDetailsAsync(
        [FromRoute][Required] Guid id,
        CancellationToken cancellationToken = default)
    {
        var query = new GetDepartmentDetailsQuery(id);
        var department = await mediator.Send(query, cancellationToken);
        return Ok(department);
    }


    [HttpPost]
    [ProducesResponseType(typeof(Guid), 200)]
    public async Task<IActionResult> CreateDepartment(
        [FromQuery][Required] CreateDepartmentsRequest request,
        CancellationToken cancellationToken)
    {
        var command = new CreateDepartmentCommand(request.Name, request.FacultyId);

        var studentId = await mediator.Send(command, cancellationToken);

        return Ok(studentId);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(Guid), 200)]
    public async Task<IActionResult> DeleteDepartment(
        [FromQuery][Required] DeleteDepartmentRequest request,
        CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteDepartmentCommand(request.Id), cancellationToken);
        return Ok(request.Id);
    }
}
