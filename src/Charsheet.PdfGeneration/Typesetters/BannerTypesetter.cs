using Charsheet.CommonModel;
using Charsheet.CommonModel.Options;
using Charsheet.PdfGeneration.DocumentComponents;
using Charsheet.PdfGeneration.PrintModel;
using Charsheet.PdfGeneration.Renderers;
using Charsheet.PdfGeneration.Renderers.Dice;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace Charsheet.PdfGeneration.Typesetters;

public class BannerTypesetter(CellRendererFactory cellRendererFactory)
{
    internal Table Typeset(CharacterPrintData characterData, CharSheetOptions opt)
    {
        LayoutTable table = new([2, 3, 2]);


        Cell namesCell = new LayoutCell().SetHorizontalAlignment(HorizontalAlignment.CENTER)
            .SetVerticalAlignment(VerticalAlignment.MIDDLE);
        namesCell.Add(new Paragraph(characterData.Name)
            .SetTextAlignment(TextAlignment.CENTER)
            .SetFontSize(16));
        if (characterData.PlayerName is not null)
        {
            namesCell.Add(new Paragraph($"Played by: {characterData.PlayerName}")
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(10)
                .SetFontColor(DeviceGray.GRAY));
        }
        table.AddCell(namesCell);

        Cell imageCell = new LayoutCell()
            .SetBorder(new OutsetBorder(DeviceGray.MakeLighter(DeviceGray.GRAY), 3));

        if (characterData.ImageName != null && File.Exists(characterData.ImageName))
        {
            ImageData imageData = ImageDataFactory.Create(characterData.ImageName);
            imageCell.Add(new Image(imageData)
                .ScaleToFit(400, 90)
                .SetHorizontalAlignment(HorizontalAlignment.CENTER));
        }
        else
        {
            imageCell.Add(new Paragraph(""));
        }

        table.AddCell(imageCell.SetHeight(90));

        Cell classesCell = new LayoutCell()
                .SetTextAlignment(TextAlignment.CENTER)
                .SetVerticalAlignment(VerticalAlignment.MIDDLE)
            ;

        classesCell
            .Add(new Paragraph($"{characterData.Species}")
                .SetMarginBottom(5))
            .Add(new Paragraph($"{characterData.Background}")
                .SetMarginBottom(5))
            ;

        foreach (ClassLevel classLevel in characterData.ClassLevels)
        {
            classesCell.Add(new Paragraph($"{classLevel.ClassName} ({classLevel.SubClassName}) {classLevel.Level}"));
        }

        DieCellRenderer d20CellRenderer = cellRendererFactory.CreateDieCellRenderer(classesCell, DiceSides.Twenty, opt.DiceRenderStyle);
        classesCell.SetNextRenderer(d20CellRenderer);
        table.AddCell(classesCell);
        return table;
    }
}
