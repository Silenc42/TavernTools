using iText.Kernel.Geom;
using iText.Kernel.Pdf.Canvas;
using iText.Layout.Element;
using iText.Layout.Renderer;

namespace Charsheet.PdfGeneration.Renderers;

internal abstract class CellRendererBase(Cell modelElement) : CellRenderer(modelElement)
{
    public override void Draw(DrawContext drawContext)
    {
        // Get the canvas to draw on
        PdfCanvas canvas = drawContext.GetCanvas();
        Rectangle rect = GetOccupiedAreaBBox();

        // Perform your drawing operations (e.g., filling with color or drawing shapes)
        canvas.SaveState();

        DrawMotive(rect, canvas);

        canvas.RestoreState();

        // Call base method to draw the cell's content on top
        base.Draw(drawContext);
    }

    protected abstract void DrawMotive(Rectangle rect, PdfCanvas canvas);
}
