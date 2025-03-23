using FluentValidation;
using University.Core.Domain.Students.Data;

namespace University.Core.Domain.Students.Validator;

public class CreateStudentValidator : AbstractValidator<CreateStudentData>
{
    public CreateStudentValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("Student's first name cannot be empty")
            .MaximumLength(50).WithMessage("First name is too long");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Student's last name cannot be empty")
            .MaximumLength(50).WithMessage("Last name is too long");

        RuleFor(x => x.MiddleName)
            .MaximumLength(50).WithMessage("Middle name is too long");

        RuleFor(x => x.PassportSerialNumber)
            .NotEmpty().WithMessage("Passport serial number cannot be empty")
            .Matches(@"^[A-Z0-9]+$").WithMessage("Invalid passport serial number format")
            .MaximumLength(10).WithMessage("Passport serial number is too long");

        RuleFor(x => x.GroupId)
            .NotEmpty().WithMessage("Student must belong to a group");
    }
}
