using Charsheet.CommonModel.Options;
using Charsheet.PdfGeneration.DocumentComponents;
using Charsheet.PdfGeneration.PrintModel;
using Charsheet.PdfGeneration.Typesetters.BlockTypesetters;
using iText.Layout.Element;

namespace Charsheet.PdfGeneration.Typesetters;

public class Column2Typesetter(BlockTypesetter blockTypesetter)
{
    internal Table Typeset(CharacterPrintData characterData, CharSheetOptions opt)
    {
        LayoutTable statsColumnTable = new(1);

        statsColumnTable
            .AddLayoutCell(blockTypesetter.AcBlock(characterData), c => c
                .SetPaddingBottom(20)
            )
            .AddLayoutCell(blockTypesetter.HpBlock(characterData, opt.DiceRenderStyle),
                c => c.SetPaddingBottom(10))
            .AddLayoutCell(blockTypesetter.InitAndSpeedBlock(characterData),
                c => c.SetPaddingBottom(10))
            .AddLayoutCell(blockTypesetter.SkillsBlock(characterData, opt.SkillListing))
            ;
        return statsColumnTable;
    }
}
