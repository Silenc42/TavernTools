namespace Charsheet.PdfGeneration.PrintModel;

public class Attack
{
    public required string Name { get; init; }
    public int? AtkBonus { get; init; }
    public required string Damage { get; init; }
    public string Notes { get; init; } = "";
}
