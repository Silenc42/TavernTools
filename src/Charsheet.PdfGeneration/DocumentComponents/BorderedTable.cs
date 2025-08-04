using iText.Kernel.Colors;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace Charsheet.PdfGeneration.DocumentComponents;

internal class BorderedTable : Table
{
    public BorderedTable(int numColumns) : base(numColumns)
    {
        StyleThis();
    }

    private void StyleThis()
    {
        SetFixedLayout();
        UseAllAvailableWidth();
        SetHorizontalAlignment(HorizontalAlignment.CENTER);
        SetTextAlignment(TextAlignment.CENTER);
        SetBorder(new InsetBorder(DeviceGray.MakeLighter(DeviceGray.GRAY), 3));
    }
}
