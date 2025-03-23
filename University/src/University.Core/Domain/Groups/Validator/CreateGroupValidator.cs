using FluentValidation;
using University.Core.Domain.Groups.Data;

namespace University.Core.Domain.Groups.Validator;

public class CreateGroupValidator : AbstractValidator<CreateGroupData>
{
    public CreateGroupValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Group name cannot be empty")
            .MaximumLength(100)
            .WithMessage("Group name is too long");

        RuleFor(x => x.DepartmentId)
            .NotEmpty()
            .WithMessage("Department must be specified");
    }

}
