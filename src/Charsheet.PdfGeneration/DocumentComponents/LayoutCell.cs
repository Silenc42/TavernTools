using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace Charsheet.PdfGeneration.DocumentComponents;

internal class LayoutCell : Cell
{
    public LayoutCell()
    {
        StyleThis();
    }

    public LayoutCell(int rowspan, int colspan) : base(rowspan, colspan)
    {
        StyleThis();
    }

    private void StyleThis()
    {
        SetMargin(-2.5f);

        SetHorizontalAlignment(HorizontalAlignment.CENTER);
        SetTextAlignment(TextAlignment.CENTER);

        SetBorder(Border.NO_BORDER);
    }
}
