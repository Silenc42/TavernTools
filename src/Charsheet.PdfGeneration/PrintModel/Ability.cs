using Charsheet.CommonModel;

namespace Charsheet.PdfGeneration.PrintModel;


public class PrintAbility
{
    public required string Title { get; init; }
    public string Description { get; init; } = "";
}

public class ActivePrintAbility : PrintAbility
{
    public AbilityCharges? Charges { get; init; }
}

public class PassivePrintAbility : PrintAbility
{
    public required bool IsIntegratedInCalculations { get; init; }
}
