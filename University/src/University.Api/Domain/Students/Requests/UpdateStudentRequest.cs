using System.ComponentModel.DataAnnotations;

namespace University.Api.Domain.Students.Requests;

public record UpdateStudentRequest
{
    public Guid Id { get; init; }

    [Required]
    public string FirstName { get; init; }

    [Required]
    public string LastName { get; init; }

    public string MiddleName { get; init; }

    [Required]
    public string PasportSerialNumber { get; init; }
}
