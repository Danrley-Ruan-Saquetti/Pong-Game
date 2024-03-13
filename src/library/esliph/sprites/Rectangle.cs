using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Library.Esliph.Utils;
using Library.Esliph.Core;

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
        get { return this.rectangle.X; }
        set { this.rectangle.X = (int)value; }
    }
    public float Y
    {
        get { return this.rectangle.Y; }
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
        get { return this.rectangle.Width; }
        set { this.rectangle.Width = (int)value; }
    }
    public float Height
    {
        get { return this.rectangle.Height; }
        set { this.rectangle.Height = (int)value; }
    }

    public RectangleSprite(Vector2 position = new(), Dimension dimension = default, float rotation = 0, Texture2D texture2D = null, Color color = new()) : base(texture2D, rotation, color)
    {
        this.rectangle = new((int)position.X, (int)position.Y, (int)dimension.Width, (int)dimension.Height);
    }

    public override void Draw(GameTime gameTime)
    {
        SpriteBatchExtensions.DrawRectangleFilled(this.GetRectangle(), this.GetColor());

        base.Draw(gameTime);
    }

    public virtual bool Intersects(RectangleSprite rectangle)
    {
        return this.rectangle.Intersects(rectangle.GetRectangle());
    }

    public virtual bool Contains(RectangleSprite rectangle)
    {
        return this.rectangle.Contains(rectangle.GetRectangle());
    }

    public virtual bool Intersects(CircleSprite circle)
    {

        return false;
    }

    public Rectangle GetRectangle()
    {
        return this.rectangle;
    }
}