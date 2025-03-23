using MediatR;

namespace University.Application.Domain.Groups.Commands.DeleteGroup;

public record DeleteGroupCommand(IReadOnlyCollection<Guid> Ids) : IRequest;

