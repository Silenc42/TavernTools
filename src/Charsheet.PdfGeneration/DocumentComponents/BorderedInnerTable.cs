using iText.Kernel.Colors;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace Charsheet.PdfGeneration.DocumentComponents;

internal class BorderedInnerTable : Table
{
    public BorderedInnerTable(float[] pointColumnWidths)
        : base(pointColumnWidths)
    {
        StyleThis();
    }

    public BorderedInnerTable(int numColumns) : base(numColumns)
    {
        StyleThis();
    }

    private void StyleThis()
    {
        SetFixedLayout();
        UseAllAvailableWidth();
        SetHorizontalAlignment(HorizontalAlignment.CENTER);
        SetTextAlignment(TextAlignment.CENTER);
        SetBorder(Border.NO_BORDER);
        //SetBorderTop(new DashedBorder(DeviceCmyk.CYAN, 1));
        SetBorderTop(new DashedBorder(DeviceGray.MakeLighter(DeviceGray.GRAY), 1));
        SetMargins(-2,-2,-2,-2);
    }
}
