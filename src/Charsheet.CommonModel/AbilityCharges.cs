namespace Charsheet.CommonModel;

public class AbilityCharges
{
    public required int MaxCharges { get; init; }
    public required AbilityRechargeCondition Recharges { get; init; }
}
