using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Library.Esliph.Core;

public class SpriteBatchExtensions
{
    private static SpriteBatch spriteBatch;
    private static readonly Pixel pixel = new();

    public SpriteBatchExtensions()
    { }

    public virtual void LoadContent(GraphicsDevice graphicsDevice)
    {
        SpriteBatchExtensions.spriteBatch = new(graphicsDevice);
        SpriteBatchExtensions.pixel.LoadContent(graphicsDevice);
    }

    public void DrawRectangle(Rectangle rectangle, Color color)
    {
        SpriteBatchExtensions.spriteBatch.Draw(SpriteBatchExtensions.pixel.GetTexture2D(), rectangle, color);
    }

    public void DrawCircle(Vector2 center, float radius, int segments, Color color)
    {
        float angle = MathHelper.TwoPi / segments;
        float currentAngle = 0f;
        Vector2[] points = new Vector2[segments];

        for (int i = 0; i < segments; i++)
        {
            points[i] = center + radius * new Vector2((float)Math.Cos(currentAngle), (float)Math.Sin(currentAngle));
            currentAngle += angle;
        }

        this.DrawPolygon(points, color);
    }

    public void DrawTriangle(Vector2 point1, Vector2 point2, Vector2 point3, Color color)
    {
        Vector2[] points = { point1, point2, point3 };
        this.DrawPolygon(points, color);
    }

    public void DrawPolygon(Vector2[] points, Color color)
    {
        for (int i = 0; i < points.Length; i++)
        {
            Vector2 p1 = points[i];
            Vector2 p2 = points[(i + 1) % points.Length];
            this.DrawLine(p1, p2, color);
        }
    }

    public void DrawLine(Vector2 point1, Vector2 point2, Color color)
    {
        Vector2 edge = point2 - point1;
        float angle = (float)Math.Atan2(edge.Y, edge.X);
        SpriteBatchExtensions.spriteBatch.Draw(SpriteBatchExtensions.pixel.GetTexture2D(), point1, null, color, angle, Vector2.Zero, new Vector2(edge.Length(), 1), SpriteEffects.None, 0);
    }
}