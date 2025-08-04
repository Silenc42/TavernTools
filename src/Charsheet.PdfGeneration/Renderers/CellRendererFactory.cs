using Charsheet.CommonModel.Options;
using Charsheet.PdfGeneration.Renderers.Dice;
using iText.Layout.Element;

namespace Charsheet.PdfGeneration.Renderers;

public class CellRendererFactory(DieRenderingCalculator dieRenderingCalculator, DieDrawer dieRenderingDrawer)
{
    internal HeartCellRenderer CreateHeartCellRenderer(Cell modelElement)
    {
        return new HeartCellRenderer(modelElement);
    }

    internal GreyShieldCellRenderer CreateGreyShieldCellRenderer(Cell modelElement)
    {
        return new GreyShieldCellRenderer(modelElement);
    }

    internal DieCellRenderer CreateDieCellRenderer(
        Cell modelElement,
        DiceSides sides,
        DiceRenderingStyle diceStyle,
        float scale = 1)
    {
        return new DieCellRenderer(dieRenderingCalculator,
            dieRenderingDrawer,
            modelElement,
            sides,
            diceStyle,
            scale
        );
    }
}
