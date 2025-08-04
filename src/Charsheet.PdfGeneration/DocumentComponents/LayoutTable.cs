using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace Charsheet.PdfGeneration.DocumentComponents;

internal class LayoutTable : Table
{
    public LayoutTable(float[] pointColumnWidths)
        : base(pointColumnWidths)
    {
        StyleThis();
    }

    public LayoutTable(int numColumns) : base(numColumns)
    {
        StyleThis();
    }

    private void StyleThis()
    {
        SetPadding(0);
        SetMargin(-2.5f);

        SetFixedLayout();
        UseAllAvailableWidth();

        SetHorizontalAlignment(HorizontalAlignment.CENTER);
        SetTextAlignment(TextAlignment.CENTER);

        SetBorder(Border.NO_BORDER);
    }
}
