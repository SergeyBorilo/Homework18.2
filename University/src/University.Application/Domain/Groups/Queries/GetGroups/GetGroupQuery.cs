using MediatR;
using University.Application.Common;

namespace University.Application.Domain.Groups.Queries.GetGroups;

public record GetGroupQuery(int PageNumber, int PageSize) : IRequest<GroupDto[]>, IRequest<PageResponse<GroupDto[]>>;
