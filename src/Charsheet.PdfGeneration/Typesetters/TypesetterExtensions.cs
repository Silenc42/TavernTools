using Charsheet.CommonModel;
using Charsheet.PdfGeneration.DocumentComponents;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace Charsheet.PdfGeneration.Typesetters;

public static class TypesetterExtensions
{
    public static string AsSignedString(this int? mod)
    {
        return mod switch
        {
            null => "_",
            > 0 => $"+{mod}",
            <= 0 => $"{mod}"
        };
    }

    public static string AsSignedString(this int mod)
    {
        return mod switch
        {
            > 0 => $"+{mod}",
            <= 0 => $"{mod}"
        };
    }

    public static string AsDisplayString(this AbilityRechargeCondition rCond)
    {
        return rCond switch
        {
            AbilityRechargeCondition.Longrest => "LR",
            AbilityRechargeCondition.Shortrest => "SR",
            AbilityRechargeCondition.Dusk => "Dusk",
            AbilityRechargeCondition.Dawn => "Dawn",
            AbilityRechargeCondition.Round => "Round",
            AbilityRechargeCondition.Turn => "Turn",
            AbilityRechargeCondition.YourTurn => "Your Turn",
            _ => throw new ArgumentOutOfRangeException(nameof(rCond), rCond, null)
        };
    }

    public static string AsDisplayString(this SkillsInGame skill)
    {
        return skill switch
        {
            SkillsInGame.Acrobatics => "Acrobatics",
            SkillsInGame.AnimalHandling => "Animal Handling",
            SkillsInGame.Arcana => "Arcana",
            SkillsInGame.Athletics => "Athletics",
            SkillsInGame.Deception => "Deception",
            SkillsInGame.History => "History",
            SkillsInGame.Insight => "Insight",
            SkillsInGame.Intimidation => "Intimidation",
            SkillsInGame.Investigation => "Investigation",
            SkillsInGame.Medicine => "Medicine",
            SkillsInGame.Nature => "Nature",
            SkillsInGame.Perception => "Perception",
            SkillsInGame.Performance => "Performance",
            SkillsInGame.Persuasion => "Persuasion",
            SkillsInGame.Religion => "Religion",
            SkillsInGame.SleightOfHand => "Sleight of Hand",
            SkillsInGame.Stealth => "Stealth",
            SkillsInGame.Survival => "Survival",
            _ => throw new ArgumentOutOfRangeException(nameof(skill), skill, null)
        };
    }

    public static string StatDisplayText(this Stats stat)
    {
        return stat switch
        {
            Stats.Str => "Str",
            Stats.Dex => "Dex",
            Stats.Con => "Con",
            Stats.Int => "Int",
            Stats.Wis => "Wis",
            Stats.Cha => "Cha",
            _ => throw new ArgumentOutOfRangeException(nameof(stat), stat, null)
        };
    }

    public static T UseBoldFont<T>(this ElementPropertyContainer<T> block) where T : IPropertyContainer
    {
        return block.SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD));
    }

    public static T UseDefaultFont<T>(this ElementPropertyContainer<T> block) where T : IPropertyContainer
    {
        return block.SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA));
    }

    internal static TTable AddLayoutCell<T, TTable>(this TTable table,
        BlockElement<T>? blockElement,
        Func<Cell, Cell>? additionalStyling = null)
        where T : IElement
        where TTable : Table
    {
        return AddLayoutCell(table, blockElement, additionalStyling, new LayoutCell());
    }

    public static TTable AddLayoutCell<T, TTable>(this TTable table,
        int rowspan,
        int colspan,
        BlockElement<T>? blockElement,
        Func<Cell, Cell>? additionalStyling = null)
        where T : IElement
        where TTable : Table
    {
        return AddLayoutCell(table, blockElement, additionalStyling, new LayoutCell(rowspan, colspan));
    }

    private static TTable AddLayoutCell<T, TTable>(TTable table, BlockElement<T>? blockElement, Func<Cell, Cell>? additionalStyling, Cell cell) where T : IElement where TTable : Table
    {
        if (blockElement is null)
        {
            return table;
        }

        cell.Add(blockElement);
        additionalStyling?.Invoke(cell);
        table.AddCell(cell);

        return table;
    }

    public static Paragraph? DescriptionStyle(this Paragraph paragraph)
    {
        return paragraph
                .SetFontSize(7)
                .SetTextAlignment(TextAlignment.JUSTIFIED)
                .SetMarginLeft(3)
                .SetMarginRight(3)
            ;
    }
}
