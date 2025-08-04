using System.Numerics;

namespace Charsheet.PdfGeneration.Renderers.Dice.DiceDefinitions;

internal class D10 : DieDefinitionBase
{
    private readonly float _c0 = (float)(Math.Sqrt(5) - 1) / 4;
    private readonly float _c1 = (float)(1 + Math.Sqrt(5)) / 4;
    private readonly float _c2 = (float)(3 + Math.Sqrt(5)) / 4;

    internal override Vector3[] BaseVertices =>
    [
        new(0.0f, _c0, _c1),
        new(0.0f, _c0, -_c1),
        new(0.0f, -_c0, _c1),
        new(0.0f, -_c0, -_c1),
        new(0.5f, 0.5f, 0.5f),
        new(0.5f, 0.5f, -0.5f),
        new(-0.5f, -0.5f, 0.5f),
        new(-0.5f, -0.5f, -0.5f),
        new(_c2, -_c1, 0.0f),
        new(-_c2, _c1, 0.0f),
        new(_c0, _c1, 0.0f),
        new(-_c0, -_c1, 0.0f),
    ];

    internal override (int i, int j)[] Edges =>
    [
        (8, 2),
        (8, 11),
        (8, 3),
        (8, 5),
        (8, 4),
        (9, 0),
        (9, 10),
        (9, 1),
        (9, 7),
        (9, 6),

        (2, 6),
        (11, 7),
        (3, 1),
        (5, 10),
        (4, 0),
        (0, 4),
        (10, 5),
        (1, 3),
        (7, 11),
        (6, 2),

        (6, 11),
        (7, 3),
        (1, 5),
        (10, 4),
        (0, 2),
        (4, 10),
        (5, 1),
        (3, 7),
        (11, 6),
        (2, 0),
    ];

    internal override List<int[]> Faces =>
    [
        [8, 2, 6, 11],
        [8, 11, 7, 3],
        [8, 3, 1, 5],
        [8, 5, 10, 4],
        [8, 4, 0, 2],
        [9, 0, 4, 10],
        [9, 10, 5, 1],
        [9, 1, 3, 7],
        [9, 7, 11, 6],
        [9, 6, 2, 0],
    ];

    internal override Matrix4x4[] Rotations => [RotateZ(25),RotateY(20)];
    internal override float Scale => 6.0f;
}
