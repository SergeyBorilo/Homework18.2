using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using University.Api.Domain.Groups.Requests;
using University.Application.Common;
using University.Application.Domain.Groups.Commands.CreateGroup;
using University.Application.Domain.Groups.Commands.DeleteGroup;
using University.Application.Domain.Groups.Queries.GetGroupDetails;
using University.Application.Domain.Groups.Queries.GetGroups;

namespace University.Api.Domain.Groups;

[Route("api/group")]
[ApiController]
public class GroupsController(Mediator mediator) : Controller
{
    [HttpGet]
    [ProducesResponseType(typeof(PageResponse<GroupDto[]>), 200)]
    public async Task<IActionResult> GetGroups(
        [FromQuery][Required] int pageSize = 1,
        [FromQuery][Required] int pageNumber = 10,
        CancellationToken cancellationToken = default)
    {
        var query = new GetGroupQuery(pageSize, pageNumber);
        var groups = await mediator.Send(query, cancellationToken);
        return Ok(groups);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GroupDetailsDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetGroupDetailsAsync(
        [FromRoute][Required] Guid id,
        CancellationToken cancellationToken = default)
    {
        var query = new GetGroupDetailsQuery(id);
        var groups = await mediator.Send(query, cancellationToken);
        return Ok(groups);
    }


    [HttpPost]
    [ProducesResponseType(typeof(Guid), 200)]
    public async Task<IActionResult> CreateGroup(
        [FromQuery][Required] CreateGroupsRequest request,
        CancellationToken cancellationToken)
    {
        var command = new CreateGroupCommand(request.Name, request.DepartmentId);

        var id = await mediator.Send(command, cancellationToken);

        return Ok(id);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(Guid), 200)]
    public async Task<IActionResult> DeleteGroup(
        [FromQuery][Required] DeleteGroupRequest request,
        CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteGroupCommand([request.Id]), cancellationToken);
        return Ok();
    }
}
