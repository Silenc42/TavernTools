using System.Text.Json.Serialization;
using Charsheet.CommonModel;

namespace Charsheet.Charbuilder.CharModel;

[JsonDerivedType(typeof(ActiveAbility), "ActiveAbility")]
[JsonDerivedType(typeof(PassiveAbility), "PassiveAbility")]
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
