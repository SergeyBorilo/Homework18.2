using MediatR;

namespace University.Application.Domain.Students.Queries.GetStudentDetails;

public record GetStudentDetailsQuery(Guid Id) : IRequest<StudentDetailsDto>;
