using Charsheet.CommonModel.Options;
using Charsheet.PdfGeneration.Renderers.Dice;
using Charsheet.PdfGeneration.Renderers.Dice.DiceDefinitions;
using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Kernel.Pdf.Canvas;
using iText.Layout.Element;

namespace Charsheet.PdfGeneration.Renderers;

internal class DieCellRenderer(
    DieRenderingCalculator dieRenderingCalculator,
    DieDrawer dieRenderingDrawer,
    Cell modelElement,
    DiceSides sides,
    DiceRenderingStyle diceStyle,
    float scale = 1) : CellRendererBase(modelElement)
{
    private readonly RenderingParams _renderingParams = new()
    {
        StrokeColor = new DeviceGray(0.75f),
        FillColor = new DeviceGray(0.95f),
        LineWidth = 0.3f
    };

    protected override void DrawMotive(Rectangle rect, PdfCanvas pdfCanvas)
    {
        DieDefinitionBase dieDefinition = sides switch
        {
            DiceSides.Four => new D4(),
            DiceSides.Six => new D6(),
            DiceSides.Eight => new D8(),
            DiceSides.Ten => new D10(),
            DiceSides.Twelve => new D12(),
            DiceSides.Twenty => new D20(),
            DiceSides.Circle => new D0(),
            _ => new D0()
        };

        DieRenderData renderData = dieRenderingCalculator.CalculateDieRenderData(dieDefinition, rect, scale, diceStyle.HideCoveredVertices);

        dieRenderingDrawer.RenderDiceInStyle(pdfCanvas, renderData,diceStyle, _renderingParams);
    }
}
