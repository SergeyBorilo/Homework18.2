using MediatR;

namespace University.Application.Domain.Groups.Queries.GetGroupDetails;

public record GetGroupDetailsQuery(Guid Id) : IRequest<GroupDetailsDto>;
