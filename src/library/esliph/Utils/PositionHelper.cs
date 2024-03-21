using System;
using Microsoft.Xna.Framework;

namespace Library.Esliph.Utils;

public static class PositionHelper
{
    public static double CalculateAngle(Vector2 position1, Vector2 position2)
    {
        float differenceX = position2.X - position1.X;
        float differenceY = position2.Y - position1.Y;

        return Math.Atan2(differenceY, differenceX);
    }

    public static Vector2 CalculateNewPosition(Vector2 positionInitial, double angle, float speed, float deltaTime)
    {
        return positionInitial + PositionHelper.CalculateDistancePosition(angle, PositionHelper.CalculateDistance(speed, deltaTime));
    }

    public static Vector2 CalculateNewPosition(Vector2 positionInitial, double angle, float distance)
    {
        return positionInitial + PositionHelper.CalculateDistancePosition(angle, distance);
    }

    public static Vector2 CalculateDistancePosition(double angle, float speed, float deltaTime)
    {
        return PositionHelper.CalculateDistancePosition(angle, PositionHelper.CalculateDistance(speed, deltaTime));
    }

    public static Vector2 CalculateDistancePosition(double angle, float distance)
    {
        float deltaX = distance * (float)Math.Cos(angle);
        float deltaY = distance * (float)Math.Sin(angle);

        return new(deltaX, deltaY);
    }

    public static float CalculateDistance(float speed, float totalSecondsGameTime)
    {
        return speed * totalSecondsGameTime;
    }
}