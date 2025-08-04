using Charsheet.PdfGeneration.DocumentComponents;
using Charsheet.PdfGeneration.PrintModel;
using Charsheet.PdfGeneration.Typesetters.BlockTypesetters;
using iText.Layout.Element;

namespace Charsheet.PdfGeneration.Typesetters;

public class Column1Typesetter(BlockTypesetter blockTypesetter)
{
    internal Table Typeset(CharacterPrintData characterData)
    {
        LayoutTable statsColumnTable = new(1);

        statsColumnTable
            .AddLayoutCell(blockTypesetter.StatsAndProfBlock(characterData), cell => cell.SetPaddingBottom(15))
            .AddLayoutCell(blockTypesetter.PassiveAbilitiesBlock(characterData), cell => cell.SetPaddingBottom(5))
            .AddLayoutCell(blockTypesetter.EquipmentBlock(characterData), cell => cell.SetPaddingBottom(5))
            .AddLayoutCell(blockTypesetter.FillerBlock("Other Items",
                $"Gold: {characterData.Gold}",
                characterData.Inventory))
            .SetExtendBottomRow(true)
            ;

        return statsColumnTable;
    }
}
