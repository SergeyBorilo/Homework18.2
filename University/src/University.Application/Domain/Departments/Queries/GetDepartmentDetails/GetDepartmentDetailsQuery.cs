using MediatR;

namespace University.Application.Domain.Departments.Queries.GetDepartmentDetails;

public record GetDepartmentDetailsQuery(Guid Id) : IRequest<DepartmentDetailsDto>;
