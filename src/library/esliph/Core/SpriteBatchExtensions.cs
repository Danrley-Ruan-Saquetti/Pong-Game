using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Library.Esliph.Global;
using Library.Esliph.Sprites;

namespace Library.Esliph.Core;

public class SpriteBatchExtensions
{
    private static SpriteBatch spriteBatch;
    private static readonly Pixel pixel = new();

    public SpriteBatchExtensions() { }

    public virtual void LoadContent(GraphicsDevice graphicsDevice)
    {
        SpriteBatchExtensions.spriteBatch = new(graphicsDevice);
        SpriteBatchExtensions.pixel.LoadContent(graphicsDevice);
    }

    public void DrawRectangleFilled(Rectangle rectangle, Color color)
    {
        this.GetSpriteBatch().Draw(SpriteBatchExtensions.pixel.GetTexture2D(), rectangle, color);
    }

    public void DrawRectangleOutline(Rectangle rectangle, Color color)
    {
        this.DrawRectangleOutline(rectangle, color, Globals.SIZE_OUTLINE_BOARD_DEFAULT);
    }

    public void DrawRectangleOutline(Rectangle rectangle, Color color, float border)
    {
        Rectangle[] lines = {
            new(rectangle.X, rectangle.Y, rectangle.X + rectangle.Width, rectangle.Y),
            new(rectangle.X, rectangle.Y, rectangle.X, rectangle.Y + rectangle.Height + (int)border),
            new(rectangle.X + rectangle.Width, rectangle.Y, rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height),
            new(rectangle.X - (int)border, rectangle.Y + rectangle.Height, rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height),
        };

        for (int i = 0; i < lines.Length; i++)
        {
            this.DrawLine(new(lines[i].X, lines[i].Y), new(lines[i].Width, lines[i].Height), color, border);
            // this.GetSpriteBatch().Draw(SpriteBatchExtensions.pixel.GetTexture2D(), lines[i], color);
        }
    }

    public void DrawCircleOutline(Vector2 center, float radius, int segments, Color color)
    {
        float angle = MathHelper.TwoPi / segments;
        float currentAngle = 0f;
        Vector2[] points = new Vector2[segments];

        for (int i = 0; i < segments; i++)
        {
            points[i] = center + radius * new Vector2((float)Math.Cos(currentAngle), (float)Math.Sin(currentAngle));
            currentAngle += angle;
        }

        this.DrawPolygonOutline(points, color);
    }

    public void DrawTriangle(Vector2 point1, Vector2 point2, Vector2 point3, Color color)
    {
        Vector2[] points = { point1, point2, point3 };
        this.DrawPolygonOutline(points, color);
    }

    public void DrawPolygonFilled(Vector2[] points, Color color)
    {
        for (int i = 0; i < points.Length; i++)
        {
            Vector2 p1 = points[i];
            Vector2 p2 = points[(i + 1) % points.Length];
            this.DrawLine(p1, p2, color);
        }
    }

    public void DrawPolygonOutline(Vector2[] points, Color color)
    {
        for (int i = 0; i < points.Length; i++)
        {
            Vector2 p1 = points[i];
            Vector2 p2 = points[(i + 1) % points.Length];
            this.DrawLine(p1, p2, color, Globals.SIZE_OUTLINE_BOARD_DEFAULT);
        }
    }

    public void DrawPolygonOutline(Vector2[] points, Color color, int border)
    {
        for (int i = 0; i < points.Length; i++)
        {
            Vector2 p1 = points[i];
            Vector2 p2 = points[(i + 1) % points.Length];
            this.DrawLine(p1, p2, color, border);
        }
    }

    public void DrawLine(Vector2 point1, Vector2 point2, Color color)
    {
        this.DrawLine(point1, point2, color, Globals.SIZE_OUTLINE_BOARD_DEFAULT);
    }

    public void DrawLine(Vector2 point1, Vector2 point2, Color color, float border)
    {
        Vector2 edge = point2 - point1;
        float angle = (float)Math.Atan2(edge.Y, edge.X);
        this.GetSpriteBatch().Draw(SpriteBatchExtensions.pixel.GetTexture2D(), point1, null, color, angle, Vector2.Zero, new Vector2(edge.Length(), (int)border), SpriteEffects.None, 0);
    }

    public SpriteBatch GetSpriteBatch()
    {
        return SpriteBatchExtensions.spriteBatch;
    }
}