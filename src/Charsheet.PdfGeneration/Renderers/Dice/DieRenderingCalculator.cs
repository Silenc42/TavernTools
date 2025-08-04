using System.Numerics;
using Charsheet.PdfGeneration.Renderers.Dice.DiceDefinitions;
using iText.Kernel.Geom;

namespace Charsheet.PdfGeneration.Renderers.Dice;

public class DieRenderingCalculator(VertexVisibilityCalculator vertexVisibilityCalculator)
{
    internal DieRenderData CalculateDieRenderData(DieDefinitionBase dieDefinition, Rectangle rect, float scaleForDisplay, bool hideCoveredVertices)
    {
        List<Vector3> rotatedVertices = dieDefinition.BaseVertices
            .Select(vector3 => RotateVertices(vector3, dieDefinition.Rotations))
            .ToList();

        int[] visibleVerticesByIndex = hideCoveredVertices
            ? vertexVisibilityCalculator.DetermineVisibleVertices(rotatedVertices)
            : Enumerable.Range(0, rotatedVertices.Count).ToArray();

        IEnumerable<Vector3> visibleVertices = ReduceToVisibleVertices(rotatedVertices, visibleVerticesByIndex);
        (int i, int j)[] visibleEdges = ReduceToVisibleEdges(dieDefinition.Edges, visibleVerticesByIndex);
        List<int[]> visibleFaces = ReduceToVisibleFaces(dieDefinition.Faces, visibleVerticesByIndex);

        Vector2[] displayVertices = ProjectAndArrangeVisibleVertices(visibleVertices, rect, dieDefinition.Scale, scaleForDisplay);

        return new DieRenderData
        {
            Vertices = displayVertices,
            Edges = visibleEdges,
            Faces = visibleFaces // needed?
        };
    }

    private IEnumerable<Vector3> ReduceToVisibleVertices(List<Vector3> rotatedVertices, int[] visibleVerticesByIndex)
    {
        return rotatedVertices.Where((_, i) => visibleVerticesByIndex.Contains(i));
    }

    private (int i, int j)[] ReduceToVisibleEdges((int i, int j)[] edges, int[] visibleVerticesByIndex)
    {
        return edges.Where(e => visibleVerticesByIndex.Contains(e.i) && visibleVerticesByIndex.Contains(e.j))
            .ToArray();
    }

    private List<int[]> ReduceToVisibleFaces(List<int[]> faces, int[] visibleVerticesByIndex)
    {
        return faces.Where(f => f.All(visibleVerticesByIndex.Contains))
            .ToList();
    }

    private Vector2[] ProjectAndArrangeVisibleVertices(IEnumerable<Vector3> renderedVertices, Rectangle rect, float dieDefinitionScale, float scaleForDisplay)
    {
        float centerX = rect.GetLeft() + rect.GetWidth() / 2;
        float centerY = rect.GetBottom() + rect.GetHeight() / 2;
        return renderedVertices
            .Select(ProjectTo2D)
            .Select(v => ScaleVertices(v, dieDefinitionScale))
            .Select(v => ScaleVertices(v, scaleForDisplay))
            .Select(v => MoveVertices(v, centerX, centerY))
            .ToArray();
    }

    private Vector3 RotateVertices(Vector3 vertex, Matrix4x4[] rotations)
    {
        return rotations.Aggregate(vertex, Vector3.Transform);
    }

    private Vector2 ProjectTo2D(Vector3 vertex)
    {
        return new Vector2(vertex.X, vertex.Y);
    }

    private Vector2 ScaleVertices(Vector2 vertex, float s)
    {
        return vertex * s;
    }

    private Vector2 MoveVertices(Vector2 vertex, float x, float y)
    {
        return vertex + new Vector2(x, y);
    }
}
