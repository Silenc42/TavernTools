using System.Numerics;
using Charsheet.CommonModel.Options;
using iText.Kernel.Pdf.Canvas;

namespace Charsheet.PdfGeneration.Renderers.Dice;

public class DieDrawer
{
    internal void RenderDiceInStyle(PdfCanvas pdfCanvas, DieRenderData renderData, DiceRenderingStyle diceStyle, RenderingParams renderingParams)
    {
        if (diceStyle.FillInFaces)
        {
            DrawFaces(pdfCanvas, renderData, renderingParams); // probably just fill the convex closure of the rendered thing?
        }

        DrawEdges(pdfCanvas, renderData, renderingParams);


        if (diceStyle.MarkVertices)
        {
            DrawVertices(pdfCanvas, renderData, renderingParams);
        }
    }

    private void DrawFaces(PdfCanvas pdfCanvas, DieRenderData die, RenderingParams renderingParams)
    {
        pdfCanvas
            .SetFillColor(renderingParams.FillColor)
            .SetStrokeColor(renderingParams.StrokeColor)
            .SetLineWidth(renderingParams.LineWidth);

        foreach (int[] face in die.Faces)
        {
            pdfCanvas.MoveTo(die.Vertices[face.Last()].X, die.Vertices[face.Last()].Y);
            foreach (int i in face)
            {
                pdfCanvas.LineTo(die.Vertices[i].X, die.Vertices[i].Y);
            }

            pdfCanvas.Fill();
        }
    }

    private void DrawEdges(PdfCanvas pdfCanvas, DieRenderData die, RenderingParams renderingParams)
    {
        foreach ((int i, int j) in die.Edges)
        {
            pdfCanvas
                .MoveTo(die.Vertices[i].X, die.Vertices[i].Y)
                .LineTo(die.Vertices[j].X, die.Vertices[j].Y)
                ;
        }

        pdfCanvas
            .SetStrokeColor(renderingParams.StrokeColor)
            .SetLineWidth(renderingParams.LineWidth)
            .Stroke();
    }

    private void DrawVertices(PdfCanvas pdfCanvas, DieRenderData die, RenderingParams renderingParams)
    {
        foreach (Vector2 vertex in die.Vertices)
        {
            pdfCanvas
                .Circle(vertex.X, vertex.Y, 0.3f)
                .SetStrokeColor(renderingParams.StrokeColor)
                .SetLineWidth(renderingParams.LineWidth)
                .Stroke();
        }
    }
}
