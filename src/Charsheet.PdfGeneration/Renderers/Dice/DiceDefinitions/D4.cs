using System.Numerics;

namespace Charsheet.PdfGeneration.Renderers.Dice.DiceDefinitions;

internal class D4 : DieDefinitionBase
{
    internal override Vector3[] BaseVertices =>
    [
        new(1, 1, 1),
        new(1, -1, -1),
        new(-1, 1, -1),
        new(-1, -1, 1),
    ];

    internal override (int i, int j)[] Edges =>
    [
        (0, 1),
        (0, 2),
        (0, 3),
        (1, 2),
        (1, 3),
        (2, 3),
    ];

    internal override List<int[]> Faces => [
        [0,1,2],
        [3,1,2],
        [3,0,2],
        [3,0,1],
    ];

    internal override Matrix4x4[] Rotations => [RotateX(20),RotateY(-10)];
    internal override float Scale => 5.0f;
}
