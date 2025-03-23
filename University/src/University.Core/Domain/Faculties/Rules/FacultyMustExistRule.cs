using University.Core.Common;
using University.Core.Domain.Faculties.Common;

namespace University.Core.Domain.Faculties.Rules;

public class FacultyMustExistRule(string name, IFacultyMustExistChecker facultyMustExistChecker) : IBuisnessRuleAsync
{
    public async Task<RuleResult> CheckAsync(CancellationToken cancellationToken = default)
    {
        var isExists = await facultyMustExistChecker.ExistsAsync(name, cancellationToken);
        return Check(isExists);
    }

    private RuleResult Check(bool isExists)
    {
        if (isExists) return RuleResult.Success();
        return RuleResult.Failed($"Faculty name: '{name}' must be unique.");
    }
}
