using System.Numerics;

namespace Charsheet.PdfGeneration.Renderers.Dice.DiceDefinitions;

internal class D8: DieDefinitionBase
{
    internal override Vector3[] BaseVertices =>
    [
        new(+1, 0, 0),
        new(-1, 0, 0),
        new(0, +1, 0),
        new(0, -1, 0),
        new(0, 0, +1),
        new(0, 0, -1),
    ];

    internal override (int i, int j)[] Edges =>
    [
        (0, 2),
        (0, 3),
        (0, 4),
        (0, 5),
        (1, 2),
        (1, 3),
        (1, 4),
        (1, 5),
        (2, 4),
        (2, 5),
        (3, 4),
        (3, 5),
    ];

    internal override List<int[]> Faces =>
    [
        [0,2,4],
        [0,4,3],
        [0,3,5],
        [0,5,2],
        [1,2,4],
        [1,4,3],
        [1,3,5],
        [1,5,2],
    ];

    internal override Matrix4x4[] Rotations => [RotateX(15), RotateY(-20)];
    internal override float Scale => 7.0f;
}
