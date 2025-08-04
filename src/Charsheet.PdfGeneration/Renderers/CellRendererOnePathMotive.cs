using iText.Kernel.Geom;
using iText.Kernel.Pdf.Canvas;
using iText.Layout.Element;

namespace Charsheet.PdfGeneration.Renderers;

internal abstract class CellRendererOnePathMotive(Cell modelElement) : CellRendererBase(modelElement)
{
    protected abstract RenderingParams RenderingParams { get; }
    protected abstract float MoveDownBy { get; }
    protected abstract float HeightAddition { get; }
    protected abstract float SidePadding { get; }

    protected override void DrawMotive(Rectangle rect, PdfCanvas canvas)
    {
        float x = rect.GetLeft() + SidePadding;
        float y = rect.GetBottom() - MoveDownBy;
        float width = rect.GetWidth() - 2 * SidePadding;
        float height = rect.GetHeight() + HeightAddition;

        DrawPath(canvas, x, y, width, height);
        canvas.SetFillColor(RenderingParams.FillColor)
            .Fill();

        DrawPath(canvas, x, y, width, height);
        canvas.SetStrokeColor(RenderingParams.StrokeColor)
            .SetLineWidth(RenderingParams.LineWidth)
            .Stroke();

    }

    protected abstract void DrawPath(PdfCanvas pdfCanvas, float x, float y, float width, float height);
}
