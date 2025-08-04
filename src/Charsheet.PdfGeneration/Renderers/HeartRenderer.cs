using iText.Kernel.Colors;
using iText.Kernel.Pdf.Canvas;
using iText.Layout.Element;

namespace Charsheet.PdfGeneration.Renderers;

internal class HeartCellRenderer(Cell modelElement) : CellRendererOnePathMotive(modelElement)
{
    protected override RenderingParams RenderingParams => new()
    {
        StrokeColor = new DeviceRgb(150, 0, 0),
        FillColor = new DeviceRgb(255, 150, 150),
        LineWidth = 3
    };

    protected override float MoveDownBy => 47;
    protected override float HeightAddition => 75;
    protected override float SidePadding => 12;

    protected override void DrawPath(PdfCanvas pdfCanvas, float x, float y, float width, float height)
    {
        float heartWidth = width * 0.75f;
        float heartHeight = height * 0.8f;
        float startX = x + (width - heartWidth) / 2;
        float startY = y + (height - heartHeight) / 2;

        float midX = startX + heartWidth / 2;
        float topY = startY + heartHeight;
        float bottomY = startY + heartHeight * 0.18f;

        pdfCanvas
            .MoveTo(midX, bottomY)
            .CurveTo(midX, bottomY,
                startX, bottomY + heartHeight * 0.3f,
                startX, topY - heartHeight * 0.25f)
            .CurveTo(startX, topY + heartHeight * 0.05f,
                midX - heartWidth * 0.3f, topY + heartHeight * 0.05f,
                midX, topY - heartHeight * 0.2f)
            .CurveTo(midX + heartWidth * 0.3f, topY + heartHeight * 0.05f,
                startX + heartWidth, topY + heartHeight * 0.05f,
                startX + heartWidth, topY - heartHeight * 0.25f)
            .CurveTo(startX + heartWidth, bottomY + heartHeight * 0.3f,
                midX, bottomY,
                midX, bottomY)
            .ClosePath();
    }
}
