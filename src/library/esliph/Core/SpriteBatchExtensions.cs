using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Library.Esliph.Global;

namespace Library.Esliph.Core;

public class SpriteBatchExtensions
{
    private static SpriteBatch shapeBatch;
    private static readonly Pixel pixel = new();

    public SpriteBatchExtensions() { }

    public static void LoadContent(GraphicsDevice graphicsDevice)
    {
        SpriteBatchExtensions.shapeBatch = new(graphicsDevice);
        SpriteBatchExtensions.pixel.LoadContent(graphicsDevice);
    }

    public static void DrawRectangleFilled(Rectangle rectangle, Color color)
    {
        SpriteBatchExtensions.GetSpriteBatch().Draw(SpriteBatchExtensions.pixel.GetTexture2D(), rectangle, color);
    }

    public static void DrawRectangleOutline(Rectangle rectangle, Color color)
    {
        SpriteBatchExtensions.DrawRectangleOutline(rectangle, color, GlobalCore.SIZE_OUTLINE_BOARD_DEFAULT);
    }

    public static void DrawRectangleOutline(Rectangle rectangle, Color color, float border)
    {
        Rectangle[] lines = {
            new(rectangle.X, rectangle.Y, rectangle.X + rectangle.Width, rectangle.Y),
            new(rectangle.X, rectangle.Y, rectangle.X, rectangle.Y + rectangle.Height + (int)border),
            new(rectangle.X + rectangle.Width, rectangle.Y, rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height),
            new(rectangle.X - (int)border, rectangle.Y + rectangle.Height, rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height),
        };

        for (int i = 0; i < lines.Length; i++)
        {
            SpriteBatchExtensions.DrawLine(new(lines[i].X, lines[i].Y), new(lines[i].Width, lines[i].Height), color, border);
            // SpriteBatchExtensions.GetSpriteBatch().Draw(SpriteBatchExtensions.pixel.GetTexture2D(), lines[i], color);
        }
    }

    public static void DrawCircleOutline(Vector2 center, float radius, int segments, Color color)
    {
        float angle = MathHelper.TwoPi / segments;
        float currentAngle = 0f;
        Vector2[] points = new Vector2[segments];

        for (int i = 0; i < segments; i++)
        {
            points[i] = center + radius * new Vector2((float)Math.Cos(currentAngle), (float)Math.Sin(currentAngle));
            currentAngle += angle;
        }

        SpriteBatchExtensions.DrawPolygonOutline(points, color);
    }

    public static void DrawTriangle(Vector2 point1, Vector2 point2, Vector2 point3, Color color)
    {
        Vector2[] points = { point1, point2, point3 };
        SpriteBatchExtensions.DrawPolygonOutline(points, color);
    }

    public static void DrawPolygonFilled(Vector2[] points, Color color)
    {
        for (int i = 0; i < points.Length; i++)
        {
            Vector2 p1 = points[i];
            Vector2 p2 = points[(i + 1) % points.Length];
            SpriteBatchExtensions.DrawLine(p1, p2, color);
        }
    }

    public static void DrawPolygonOutline(Vector2[] points, Color color)
    {
        for (int i = 0; i < points.Length; i++)
        {
            Vector2 p1 = points[i];
            Vector2 p2 = points[(i + 1) % points.Length];
            SpriteBatchExtensions.DrawLine(p1, p2, color, GlobalCore.SIZE_OUTLINE_BOARD_DEFAULT);
        }
    }

    public static void DrawPolygonOutline(Vector2[] points, Color color, int border)
    {
        for (int i = 0; i < points.Length; i++)
        {
            Vector2 p1 = points[i];
            Vector2 p2 = points[(i + 1) % points.Length];
            SpriteBatchExtensions.DrawLine(p1, p2, color, border);
        }
    }

    public static void DrawLine(Vector2 point1, Vector2 point2, Color color)
    {
        SpriteBatchExtensions.DrawLine(point1, point2, color, GlobalCore.SIZE_OUTLINE_BOARD_DEFAULT);
    }

    public static void DrawLine(Vector2 point1, Vector2 point2, Color color, float border)
    {
        Vector2 edge = point2 - point1;
        float angle = (float)Math.Atan2(edge.Y, edge.X);
        SpriteBatchExtensions.GetSpriteBatch().Draw(SpriteBatchExtensions.pixel.GetTexture2D(), point1, null, color, angle, Vector2.Zero, new Vector2(edge.Length(), (int)border), SpriteEffects.None, 0);
    }

    public static void DrawTexture2D(Texture2D texture2D, Rectangle rectangle)
    {
        SpriteBatchExtensions.GetSpriteBatch().Draw(texture2D, rectangle, Color.White);
    }

    public static SpriteBatch GetSpriteBatch()
    {
        return SpriteBatchExtensions.shapeBatch;
    }
}