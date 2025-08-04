using System.Numerics;

namespace Charsheet.PdfGeneration.Renderers.Dice;

internal class DieRenderData
{
    internal required Vector2[] Vertices { get; init; }

    internal required (int i, int j)[] Edges { get; init;}

    internal required List<int[]> Faces { get;init; }
}
