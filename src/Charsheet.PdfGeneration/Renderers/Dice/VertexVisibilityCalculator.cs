using System.Numerics;

namespace Charsheet.PdfGeneration.Renderers.Dice;

public class VertexVisibilityCalculator
{
    public int[] DetermineVisibleVertices(List<Vector3> vertices)
    {
        return Enumerable.Range(0, vertices.Count).ToArray(); //todo: implement algorithm.
    }
}
