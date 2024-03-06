using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Library.Esliph.Components;

public class Body
{
    protected Rectangle rectangle;
    protected Texture2D texture;
    public Position position
    {
        get
        {
            return new(this.rectangle.X, this.rectangle.Y);
        }
        set
        {
            this.rectangle.X = value.X;
            this.rectangle.Y = value.Y;
        }
    }
    public Dimension dimension
    {
        get
        {
            return new(this.rectangle.Width, this.rectangle.Height);
        }
        set
        {
            this.rectangle.Width = value.Width;
            this.rectangle.Height = value.Height;
        }
    }

    public Body() { }
    public Body(Rectangle rectangle)
    {
        this.rectangle = rectangle;
        this.texture = null;
    }
    public Body(int x, int y, int width, int height)
    {
        this.rectangle = new(x, y, width, height);
        this.texture = null;
    }
    public Body(Texture2D texture)
    {
        this.texture = texture;
        this.rectangle = new();
    }
    public Body(Rectangle rectangle, Texture2D texture)
    {
        this.texture = texture;
        this.rectangle = rectangle;
    }

    public Rectangle GetRectangle()
    {
        return this.rectangle;
    }

    public Texture2D GetTexture2D()
    {
        return this.texture;
    }

    public void SetTexture2D(Texture2D texture)
    {
        this.texture = texture;
    }

    public Bounds GetBounds()
    {
        return new(this.position, this.dimension);
    }
}