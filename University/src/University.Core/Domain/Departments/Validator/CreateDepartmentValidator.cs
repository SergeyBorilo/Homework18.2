using FluentValidation;
using University.Core.Domain.Departments.Data;

namespace University.Core.Domain.Departments.Validator;

internal class CreateDepartmentValidator : AbstractValidator<CreateDepartmentData>
{
    public CreateDepartmentValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Назва кафедри не може бути порожньою")
            .MaximumLength(100).WithMessage("Назва кафедри занадто довга");

        RuleFor(x => x.FacultyId)
            .NotEmpty().WithMessage("Кафедра повинна належати факультету");
    }
}
