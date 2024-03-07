using Library.Esliph.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Library.Esliph.Sprites;

public class RectangleSprite : Sprite
{
    private Rectangle rectangle;
    public Vector2 position
    {
        get { return new(this.X, this.Y); }
        set
        {
            this.X = (int)value.X;
            this.Y = (int)value.Y;
        }
    }
    public float X
    {
        get { return (float)this.rectangle.X; }
        set { this.rectangle.X = (int)value; }
    }
    public float Y
    {
        get { return (float)this.rectangle.Y; }
        set { this.rectangle.Y = (int)value; }
    }
    public Dimension dimension
    {
        get { return new(this.Width, this.Height); }
        set
        {
            this.Width = (int)value.Width;
            this.Height = (int)value.Height;
        }
    }
    public float Width
    {
        get { return (float)this.rectangle.Width; }
        set { this.rectangle.Width = (int)value; }
    }
    public float Height
    {
        get { return (float)this.rectangle.Height; }
        set { this.rectangle.Height = (int)value; }
    }

    public RectangleSprite() : base()
    {
        this.rectangle = new();
    }
    public RectangleSprite(Vector2 position, Dimension dimension) : this((int)position.X, (int)position.Y, dimension.Width, dimension.Height) { }
    public RectangleSprite(int x, int y, int width, int height) : this(null, x, y, width, height) { }
    public RectangleSprite(Texture2D texture2D, int x, int y, int width, int height) : base(texture2D)
    {
        this.rectangle = new(x, y, width, height);
    }

    public Rectangle GetRectangle()
    {
        return this.rectangle;
    }
}