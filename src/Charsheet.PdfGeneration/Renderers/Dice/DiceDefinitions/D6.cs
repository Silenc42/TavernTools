using System.Numerics;

namespace Charsheet.PdfGeneration.Renderers.Dice.DiceDefinitions;

internal class D6 : DieDefinitionBase
{
    internal override Vector3[] BaseVertices =>
    [
        new(+1, +1, +1),
        new(+1, +1, -1),
        new(+1, -1, +1),
        new(+1, -1, -1),
        new(-1, +1, +1),
        new(-1, +1, -1),
        new(-1, -1, +1),
        new(-1, -1, -1),
    ];

    internal override (int i, int j)[] Edges =>
    [
        (0, 1),
        (2, 3),
        (4, 5),
        (6, 7),
        (0, 2),
        (1, 3),
        (4, 6),
        (5, 7),
        (0, 4),
        (1, 5),
        (2, 6),
        (3, 7),
    ];

    internal override List<int[]> Faces =>
    [
        [0, 1, 3, 2],
        [4, 5, 7, 6],
        [0, 2, 6, 4],
        [1, 3, 7, 5],
        [0, 1, 5, 4],
        [2, 3, 7, 6],
    ];

    internal override Matrix4x4[] Rotations => [RotateX(15),RotateY(-20)];
    internal override float Scale => 5.0f;
}
