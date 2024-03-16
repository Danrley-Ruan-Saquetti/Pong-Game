using System;
using Library.Esliph.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Library.Esliph.Shapes;

public interface IShape2D : IComponent
{
    public void Draw(GameTime gameTime);
    public float GetRotation();
    public void Rotate(float degrees);
    public void RotateToLeft(float degrees);
    public void RotateToRight(float degrees);
    public bool IsInsideArea(Vector2 position, float radius);
    public void SetRotation(float rotation);
    public void SetColor(Color color);
    public Color GetColor();
    public void SetTexture2D(Texture2D texture2D);
    public Texture2D GetTexture2D();
}

public class Shape2D : Component, IShape2D
{
    private Texture2D texture2D;
    private float rotation;
    private Color color;

    public Shape2D(Texture2D texture2D = null, float rotation = 0, Color color = new())
    {
        this.texture2D = texture2D;
        this.rotation = rotation;
        this.color = color;
    }

    public virtual void Draw(GameTime gameTime) { }

    public float GetRotation()
    {
        return this.rotation;
    }

    public virtual bool IsInsideArea(Vector2 position, float radius)
    {
        return false;
    }

    public void Rotate(float degrees)
    {
        this.rotation += degrees;
    }

    public void RotateToLeft(float degrees)
    {
        this.rotation += Math.Abs(degrees);
    }

    public void RotateToRight(float degrees)
    {
        this.rotation -= Math.Abs(degrees);
    }

    public void SetRotation(float rotation)
    {
        this.rotation = rotation;
    }

    public void SetColor(Color color)
    {
        this.color = color;
    }

    public Color GetColor()
    {
        return this.color;
    }

    public void SetTexture2D(Texture2D texture2D)
    {
        this.texture2D = texture2D;
    }

    public Texture2D GetTexture2D()
    {
        return this.texture2D;
    }
}