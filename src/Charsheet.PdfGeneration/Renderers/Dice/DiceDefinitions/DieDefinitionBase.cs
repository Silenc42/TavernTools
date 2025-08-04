using System.Numerics;

namespace Charsheet.PdfGeneration.Renderers.Dice.DiceDefinitions;

internal abstract class DieDefinitionBase
{
    /// <summary>
    /// Vertices of the die.
    /// The order is relevant for <see cref="Edges">Edges</see>
    /// </summary>
    internal abstract Vector3[] BaseVertices { get; }

    /// <summary>
    /// Pairs of indices referring to <see cref="BaseVertices">BaseVertices</see>
    /// Make sure the edges fit to the <see cref="Faces">Faces</see>, otherwise, it may look weird.
    /// </summary>
    internal abstract (int i, int j)[] Edges { get; }

    /// <summary>
    /// Set of ordered sets of indices. Each inner set (int[]) refers to indices in <see cref="BaseVertices">BaseVertices</see> and represents one faces of the die.
    /// The order of indices within each inner set is important. It is the order in which the face will be drawn. It has to go around the face, otherwise the rendering becomes weird.
    /// Make sure the faces fit to the <see cref="Edges">Edges</see>, otherwise, it may look weird.
    /// </summary>
    internal abstract List<int[]> Faces { get; }

    /// <summary>
    /// Rotations applied to the rendering of the die
    /// </summary>
    internal abstract Matrix4x4[] Rotations { get; }

    internal abstract float Scale { get; }

    protected Matrix4x4 RotateX(int degrees)
    {
        double radians = degrees * Math.PI / 180;
        return Matrix4x4.CreateRotationX((float)radians);
    }

    protected Matrix4x4 RotateY(int degrees)
    {
        double radians = degrees * Math.PI / 180;
        return Matrix4x4.CreateRotationY((float)radians);
    }

    protected Matrix4x4 RotateZ(int degrees)
    {
        double radians = degrees * Math.PI / 180;
        return Matrix4x4.CreateRotationZ((float)radians);
    }
}
