using FluentValidation;
using University.Core.Domain.Faculties.Data;

namespace University.Core.Domain.Faculties.Validator;

public class CreateFacultyValidator : AbstractValidator<CreateFacultyData>
{
    public CreateFacultyValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Faculty name cannot be empty")
            .MaximumLength(100)
            .WithMessage("Faculty name is too long");
    }

}

