namespace University.Core.Common;

public interface IBuisnessRuleAsync
{
    Task<RuleResult> CheckAsync(CancellationToken cancellationToken = default);
}
