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
        float differenceX = vector2.X - vector1.X;
        float differenceY = vector2.Y - vector1.Y;

        return Math.Atan2(differenceY, differenceX);
    }

    public static float CalculateDistance(float speed, float totalSecondsGameTime)
    {
        return speed * totalSecondsGameTime;
    }
}