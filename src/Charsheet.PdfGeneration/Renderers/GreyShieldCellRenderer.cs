using iText.Kernel.Colors;
using iText.Kernel.Pdf.Canvas;
using iText.Layout.Element;

namespace Charsheet.PdfGeneration.Renderers;

internal class GreyShieldCellRenderer(Cell modelElement) : CellRendererOnePathMotive(modelElement)
{
    protected override RenderingParams RenderingParams => new()
    {
        StrokeColor = new DeviceGray(0.75f),
        FillColor = new DeviceGray(0.95f),
        LineWidth = 3
    };

    protected override float MoveDownBy => 15;
    protected override float HeightAddition => 25;
    protected override float SidePadding => 12;

    protected override void DrawPath(PdfCanvas pdfCanvas, float x, float y, float width, float height)
    {
        // Shield dimensions
        float shieldWidth = width * 0.7f;
        float shieldHeight = height * 0.95f;
        float startX = x + (width - shieldWidth) / 2;
        float startY = y + (height - shieldHeight) / 2;

        // Control points for Bézier curves
        float topWidth = shieldWidth * 0.92f;
        float bottomY = startY + shieldHeight * 0.02f;
        float midHeight = startY + shieldHeight * 0.65f;

        // Create a path for the realistic kite shield shape
        pdfCanvas.MoveTo(startX + shieldWidth / 2, startY + shieldHeight) // Top point
            .CurveTo(startX + shieldWidth * 0.3f, startY + shieldHeight * 0.95f,
                startX + shieldWidth * 0.15f, startY + shieldHeight * 0.92f,
                startX + (shieldWidth - topWidth) / 2, startY + shieldHeight) // Top left curve
            .CurveTo(startX, midHeight,
                startX + shieldWidth * 0.05f, startY + shieldHeight * 0.6f,
                startX + shieldWidth * 0.15f, startY + shieldHeight * 0.3f) // Left curve
            .CurveTo(startX + shieldWidth * 0.3f, startY + shieldHeight * 0.1f,
                startX + shieldWidth * 0.5f, bottomY,
                startX + shieldWidth * 0.5f, bottomY) // Bottom left curve
            .CurveTo(startX + shieldWidth * 0.5f, bottomY,
                startX + shieldWidth * 0.7f, startY + shieldHeight * 0.1f,
                startX + shieldWidth * 0.85f, startY + shieldHeight * 0.3f) // Bottom right curve
            .CurveTo(startX + shieldWidth * 0.95f, startY + shieldHeight * 0.6f,
                startX + shieldWidth, midHeight,
                startX + topWidth + (shieldWidth - topWidth) / 2, startY + shieldHeight) // Right curve
            .CurveTo(startX + shieldWidth * 0.85f, startY + shieldHeight * 0.92f,
                startX + shieldWidth * 0.7f, startY + shieldHeight * 0.95f,
                startX + shieldWidth / 2, startY + shieldHeight) // Top right curve
            .ClosePath();
    }
}
