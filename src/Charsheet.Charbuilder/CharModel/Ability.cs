using Charsheet.CommonModel;

namespace Charsheet.Charbuilder.CharModel;

public abstract class Ability
{
    public required string Title { get; init; }
    public string DescriptionLong { get; init; } = "";
    public string DescriptionShort { get; init; } = "";
}

public class ActiveAbility : Ability
{
    public AbilityCharges? Charges { get; init; }
}

public class PassiveAbility : Ability
{
    public required bool IsIntegratedInCalculations { get; init; }
}
