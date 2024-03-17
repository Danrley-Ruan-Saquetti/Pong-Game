using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Library.Esliph.Utils;
using Library.Esliph.Core;

namespace Library.Esliph.Shapes;

public interface IRectangleShape2D : IShape2D
{
    public Rectangle GetRectangle();
    public bool IsBiggestThan(IRectangleShape2D rectangleShape2D);
    public bool IsBiggestThan(ICircleShape2D rectangleShape2D);
}

public class RectangleShape2D : Shape2D, IRectangleShape2D
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
    public Vector2 center
    {
        get { return new(this.X + (this.Width / 2), this.Y + (this.Height / 2)); }
        set
        {
            this.X = (int)value.X - (this.Width / 2);
            this.Y = (int)value.Y - (this.Height / 2);
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
    public float EndX
    {
        get { return this.X + this.Width; }
        set { this.rectangle.X = (int)(value - this.Width); }
    }
    public float EndY
    {
        get { return this.Y + this.Height; }
        set { this.rectangle.X = (int)(value - this.Height); }
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

    public RectangleShape2D(Vector2 position = new(), Dimension dimension = default, float rotation = 0, Texture2D texture2D = null, Color color = new()) : base(texture2D, rotation, color)
    {
        this.rectangle = new((int)position.X, (int)position.Y, (int)dimension.Width, (int)dimension.Height);
    }

    public override void Draw(GameTime gameTime)
    {
        SpriteBatchExtensions.DrawRectangleFilled(this.GetRectangle(), this.GetColor());

        base.Draw(gameTime);
    }

    public override bool IsInsideArea(Vector2 position, float radius)
    {
        return Vector2.Distance(this.center, position) <= radius;
    }

    public Rectangle GetRectangle()
    {
        return this.rectangle;
    }

    public bool IsBiggestThan(IRectangleShape2D rectangleShape2D)
    {
        return this.Width > rectangleShape2D.GetRectangle().Width && this.Height > rectangleShape2D.GetRectangle().Height;
    }

    public bool IsBiggestThan(ICircleShape2D circleShape2D)
    {
        return this.Width / 2 > circleShape2D.GetRadius() && this.Height / 2 > circleShape2D.GetRadius();
    }
}