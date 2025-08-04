namespace Charsheet.CommonModel.Options;

public class CharSheetOptions
{
    public ListingSkillOption SkillListing { get; init; }
    public required DiceRenderingStyle DiceRenderStyle { get; init; }

}

public class DiceRenderingStyle
{
    public bool MarkVertices { get; init; }
    public bool FillInFaces { get; init; }
    public bool HideCoveredVertices { get; init; }
}
