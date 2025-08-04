using Charsheet.PdfGeneration.DocumentComponents;
using Charsheet.PdfGeneration.PrintModel;
using Charsheet.PdfGeneration.Typesetters.BlockTypesetters;
using iText.Layout.Element;

namespace Charsheet.PdfGeneration.Typesetters;

public class Column3Typesetter(BlockTypesetter blockTypesetter)
{
    internal Table Typeset(CharacterPrintData characterData)
    {
        LayoutTable statsColumnTable = new(1);

        statsColumnTable
            .AddLayoutCell(blockTypesetter.AttacksBlock(characterData), cell => cell.SetPaddingBottom(5))
            .AddLayoutCell(blockTypesetter.ActiveAbilitiesBlock(characterData), cell => cell.SetPaddingBottom(5))
            .AddLayoutCell(blockTypesetter.ConsumablesBlock(characterData), cell => cell.SetPaddingBottom(5))
            .AddLayoutCell(blockTypesetter.FillerBlock("Notes", "Inspiration: "))
            .SetExtendBottomRow(true)
            ;
        return statsColumnTable;
    }
}
