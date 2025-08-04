using System.Numerics;

namespace Charsheet.PdfGeneration.Renderers.Dice.DiceDefinitions;

internal class D0 : DieDefinitionBase
{
    internal override Vector3[] BaseVertices => [new(0, 0, 0)];
    internal override (int i, int j)[] Edges => [];
    internal override List<int[]> Faces => [];
    internal override Matrix4x4[] Rotations => [];
    internal override float Scale => 5.0f;
}
