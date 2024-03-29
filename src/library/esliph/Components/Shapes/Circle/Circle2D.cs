using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Library.Esliph.Core;
using Library.Esliph.Global;

namespace Library.Esliph.Shapes;

public interface ICircleShape2D : IShape2D
{
    public bool Intersects(CircleShape2D circle);
    public Vector2 GetPosition();
    public void SetPosition(Vector2 position);
    public float GetRadius();
    public void SetRadius(float radius);
    public int GetSegments();
    public float GetDiameter();
    public void SetSegments(int segments);
}

public class CircleShape2D : Shape2D, ICircleShape2D
{
    private Vector2 position;
    private float radius { get; set; }
    private int segments { get; set; }
    public float X
    {
        get { return this.position.X; }
        set { this.position.X = value; }
    }
    public float InitialX
    {
        get { return this.position.X - this.radius; }
        set { this.position.X = value + this.radius; }
    }
    public float EndX
    {
        get { return this.position.X + this.radius; }
        set { this.position.X = value - this.radius; }
    }
    public float Y
    {
        get { return this.position.Y; }
        set { this.position.Y = value; }
    }
    public float InitialY
    {
        get { return this.position.Y - this.radius; }
        set { this.position.Y = value + this.radius; }
    }
    public float EndY
    {
        get { return this.position.Y + this.radius; }
        set { this.position.Y = value - this.radius; }
    }
    public float diameter
    {
        get { return this.radius * 2; }
        set { this.radius = value / 2; }
    }

    public CircleShape2D(Vector2 position = new(), float radius = 0, int? segments = null, float rotation = 0, Texture2D texture2D = null, Color color = new()) : base(texture2D, rotation, color)
    {
        this.position = position;
        this.radius = radius;
        this.segments = segments ?? GlobalCore.SEGMENTS_CIRCLE_DEFAULT;
    }

    public override void Draw()
    {
        SpriteBatchExtensions.DrawCircleOutline(this.GetPosition(), this.GetRadius(), this.GetSegments(), this.GetColor());

        base.Draw();
    }

    public virtual bool Intersects(CircleShape2D circle)
    {
        return Vector2.Distance(circle.position, this.position) < this.radius + circle.radius;
    }

    public bool IsBiggestThan(IRectangleShape2D rectangleShape2D)
    {
        return this.diameter > rectangleShape2D.GetRectangle().Width && this.diameter > rectangleShape2D.GetRectangle().Height;
    }

    public bool IsBiggestThan(ICircleShape2D circleShape2D)
    {
        return this.diameter > circleShape2D.GetDiameter();
    }

    public Vector2 GetPosition()
    {
        return this.position;
    }

    public void SetPosition(Vector2 position)
    {
        this.position = position;
    }

    public float GetRadius()
    {
        return this.radius;
    }

    public void SetRadius(float radius)
    {
        this.radius = radius;
    }

    public int GetSegments()
    {
        return this.segments;
    }

    public float GetDiameter()
    {
        return this.diameter;
    }

    public void SetSegments(int segments)
    {
        this.segments = segments;
    }
}