using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Library.Esliph.Core;
using Library.Esliph.Global;

namespace Library.Esliph.Sprite2Ds;

public class CircleSprite2D : Sprite2D
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

    public CircleSprite2D(Vector2 position = new(), float radius = 0, int? segments = null, float rotation = 0, Texture2D texture2D = null, Color color = new()) : base(texture2D, rotation, color)
    {
        this.position = position;
        this.radius = radius;
        this.segments = segments ?? Globals.SEGMENTS_CIRCLE_DEFAULT;
    }

    public override void Draw(GameTime gameTime)
    {
        SpriteBatchExtensions.DrawCircleOutline(this.GetPosition(), this.GetRadius(), this.GetSegments(), this.GetColor());

        base.Draw(gameTime);
    }

    public virtual bool Intersects(CircleSprite2D circle)
    {
        return Vector2.Distance(circle.position, this.position) < this.radius + circle.radius;
    }

    public Vector2 GetPosition()
    {
        return this.position;
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

    public void SetSegments(int segments)
    {
        this.segments = segments;
    }
}