using University.Core.Common;
using University.Core.Domain.Groups.Common;

namespace University.Core.Domain.Groups.Rules;

public class GroupMustExistRule(string name, IGroupMustExistChecker groupMustExistChecker) : IBuisnessRuleAsync
{
    public async Task<RuleResult> CheckAsync(CancellationToken cancellationToken = default)
    {
        var isExists = await groupMustExistChecker.ExistsAsync(name, cancellationToken);
        return Check(isExists);
    }

    private RuleResult Check(bool isExists)
    {
        if (isExists) return RuleResult.Success();
        return RuleResult.Failed($"Group name: '{name}' must be unique.");
    }
}
