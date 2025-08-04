using System.Numerics;

namespace Charsheet.PdfGeneration.Renderers.Dice.DiceDefinitions;

internal class D20 : DieDefinitionBase
{
    private float Phi => (float)(1 + Math.Sqrt(5)) / 2;

    internal override Vector3[] BaseVertices =>
    [
        new(0, +1, +Phi),
        new(0, -1, +Phi),
        new(0, +1, -Phi),
        new(0, -1, -Phi),
        new(+1, +Phi, 0), // 4
        new(-1, +Phi, 0),
        new(+1, -Phi, 0),
        new(-1, -Phi, 0),
        new(+Phi, 0, +1), // 8
        new(+Phi, 0, -1),
        new(-Phi, 0, +1),
        new(-Phi, 0, -1),
    ];

    internal override (int i, int j)[] Edges =>
    [
        (0, 1), (2, 3), (4, 5), (6, 7), (8, 9), (10, 11),
        (0, 4), (0, 5),
        (1, 6), (1, 7),
        (2, 4), (2, 5),
        (3, 6), (3, 7),
        (4, 8), (4, 9),
        (5, 10), (5, 11),
        (6, 8), (6, 9),
        (7, 10), (7, 11),
        (8, 0), (8, 1),
        (9, 2), (9, 3),
        (10, 0), (10, 1),
        (11, 2), (11, 3),
    ];

    internal override List<int[]> Faces =>
    [
        [0, 1, 8],
        [0, 1, 10],
        [2, 3, 9],
        [2, 3, 11],
        [4, 5, 0],
        [4, 5, 2],
        [6, 7, 1],
        [6, 7, 3],
        [8, 9, 4],
        [8, 9, 6],
        [10, 11, 5],
        [10, 11, 7],

        [10, 7, 1],
        [11, 7, 3],
        [10, 5, 0],
        [11, 5, 2],

        [8, 6, 1],
        [9, 6, 3],
        [8, 4, 0],
        [9, 4, 2],
    ];

    internal override Matrix4x4[] Rotations => [RotateX(25), RotateY(-45)];
    internal override float Scale => 20.0f;
}
