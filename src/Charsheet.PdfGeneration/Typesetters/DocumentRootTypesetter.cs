using Charsheet.CommonModel.Options;
using Charsheet.PdfGeneration.DocumentComponents;
using Charsheet.PdfGeneration.PrintModel;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Layout.Renderer;

namespace Charsheet.PdfGeneration.Typesetters;

public class DocumentRootTypesetter(BannerTypesetter bannerTypesetter, Column1Typesetter column1Typesetter, Column2Typesetter column2Typesetter, Column3Typesetter column3Typesetter)
{
    public void Typeset(Document document, CharacterPrintData characterData, CharSheetOptions opt)
    {
        Table mainPage = new LayoutTable([3, 2.1f, 3])
                .AddLayoutCell(1, 3, bannerTypesetter.Typeset(characterData, opt), cell => cell.SetPaddingBottom(10))
                .AddLayoutCell(column1Typesetter.Typeset(characterData), cell => cell
                    .SetPaddingRight(5))
                .AddLayoutCell(column2Typesetter.Typeset(characterData, opt), cell => cell
                    .SetPaddingTop(25)
                    .SetPaddingLeft(10)
                    .SetPaddingRight(10))
                .AddLayoutCell(column3Typesetter.Typeset(characterData), cell => cell
                    .SetPaddingLeft(5))
                .SetExtendBottomRow(true)
            ;
        document.UseDefaultFont().SetFontSize(9);
        document.Add(mainPage);

        document.SetRenderer(new ColumnDocumentRenderer(document, [new(36, 36, 254, 770), new(295, 36, 254, 770)]));
        document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

        foreach (PrintAbility ability in characterData.AbilitiesWithFullDescription)
        {
            Paragraph par = new();
            par.Add(new Text(ability.Title + Environment.NewLine).SetFontSize(8).UseBoldFont());
            par.Add(new Text(ability.Description).SetFontSize(6));
            par.SetKeepTogether(true);
            document.Add(par);
        }

        if (characterData.BackgroundStory != null)
        {
            document.SetRenderer(new DocumentRenderer(document));
            document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
            document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

            document.Add(new Paragraph("Background").SetFontSize(12).UseBoldFont());
            document.Add(new Paragraph(characterData.BackgroundStory).SetFontSize(10));
        }
    }
}
