using iText.Kernel.Colors;

namespace Charsheet.PdfGeneration.Renderers;

internal class RenderingParams
{
    internal required Color StrokeColor {  get; init; }
    internal required Color FillColor { get; init; }
    internal float LineWidth {  get; init; }
}
