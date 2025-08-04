using Charsheet.CommonModel;

namespace Charsheet.PdfGeneration.PrintModel;

public class StatData
{
    public int Prof { get; init; }

    public StatBasedArray StatScores { get; init; } = new();
    public StatBasedArray StatMods { get; init; } = new();
    public StatBasedArray Saves { get; init; } = new();
}
