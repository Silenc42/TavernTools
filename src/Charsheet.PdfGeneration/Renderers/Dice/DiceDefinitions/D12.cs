using System.Numerics;

namespace Charsheet.PdfGeneration.Renderers.Dice.DiceDefinitions;

internal class D12 : DieDefinitionBase
{
    private float Phi => (float)(1 + Math.Sqrt(5)) / 2;
    private float ReciprocalPhi => 1 / Phi;

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
        new(0, +Phi, +ReciprocalPhi), // top front - 8
        new(0, +Phi, -ReciprocalPhi), // top back
        new(0, -Phi, +ReciprocalPhi), // bottom front
        new(0, -Phi, -ReciprocalPhi), // bottom back
        new(+Phi, +ReciprocalPhi, 0), // 12
        new(+Phi, -ReciprocalPhi, 0),
        new(-Phi, +ReciprocalPhi, 0),
        new(-Phi, -ReciprocalPhi, 0),
        new(+ReciprocalPhi, 0, +Phi), // 16
        new(-ReciprocalPhi, 0, +Phi),
        new(+ReciprocalPhi, 0, -Phi),
        new(-ReciprocalPhi, 0, -Phi),
    ];

    internal override (int i, int j)[] Edges =>
    [
        (8, 9), (10, 11), (12, 13), (14, 15), (16, 17), (18, 19), //top: front-back and analogous
        (0, 8), (0, 12), (0, 16),
        (1, 9), (1, 12), (1, 18),
        (2, 10), (2, 13), (2, 16),
        (3, 11), (3, 13), (3, 18),

        (4, 8), (4, 14), (4, 17),
        (5, 9), (5, 14), (5, 19),
        (6, 10), (6, 15), (6, 17),
        (7, 11), (7, 15), (7, 19),
    ];

    internal override List<int[]> Faces =>
    [
        [8, 9, 1, 12, 0],
        [8, 9, 5, 14, 4],
        [10, 11, 3, 13, 2],
        [10, 11, 7, 15, 6],
        [12, 13, 2, 16, 0],
        [12, 13, 3, 18, 1],
        [14, 15, 6, 17, 4],
        [14, 15, 7, 19, 5],
        [16, 17, 4, 8, 0],
        [16, 17, 6, 10, 2],
        [18, 19, 5, 9, 1],
        [18, 19, 7, 11, 3],
    ];

    internal override Matrix4x4[] Rotations => [RotateX(45)];
    internal override float Scale => 5.0f;
}
