using Charsheet.CommonModel;

namespace Charsheet.PdfGeneration.PrintModel;

public class SkillDetails
{
    public bool IsProficient => ProficiencyLevel != SkillProficiencyLevel.None;

    public required SkillProficiencyLevel ProficiencyLevel { get; init; }
    public required SkillsInGame SkillName { get; init; }
    public required StatBasedArray Modifiers { get; init; }
    public required Stats MainStat { get; init; }
}
