using System.ComponentModel.DataAnnotations;

namespace University.Application.Domain.Students.Queries.GetStudents;

public record GetStudentsDto
{
    [Required]
    public Guid Id { get; init; }

    [Required]
    public string FirstName { get; init; }

    [Required]
    public string LastName { get; init; }

    [Required]
    public string MiddleName { get; init; }

    [Required]
    public string PasportSerialNumber { get; init; }
}
