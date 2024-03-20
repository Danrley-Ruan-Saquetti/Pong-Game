using System;
using Microsoft.Xna.Framework;
using Library.Esliph.Utils;

namespace Library.Esliph.Global;

public static class GlobalCore
{
    public static readonly int
    SIZE_OUTLINE_BOARD_DEFAULT = 4,
    SEGMENTS_CIRCLE_DEFAULT = 36,
    RADIUS_CIRCLE_DEFAULT;
    public static Dimension WINDOW_DIMENSION = new(400, 500);

    public static double CalculateAngle(Vector2 vector1, Vector2 vector2)
    {
        float xDiff = vector2.X - vector1.X;
        float yDiff = vector2.Y - vector1.Y;

        return Math.Atan2(yDiff, xDiff);
    }
}