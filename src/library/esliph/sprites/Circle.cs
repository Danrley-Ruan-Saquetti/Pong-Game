using Microsoft.Xna.Framework;
using Library.Esliph.Core;
using Microsoft.Xna.Framework.Graphics;

namespace Library.Esliph.Sprites;

public class Circle : Sprite
{
    private Vector2 position;
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
    private float radius { get; set; }
    public float diameter
    {
        get { return this.radius * 2; }
        set { this.diameter = value / 2; }
    }
    private int segments { get; set; }

    public Circle(Vector2 position = new(), float radius = 0, int segments = 0, float rotation = 0, Texture2D texture2D = null, Color color = new()) : base(texture2D, rotation, color)
    {
        this.position = position;
        this.radius = radius;
        this.segments = segments;
    }

    public override void Draw(GameTime gameTime)
    {
        SpriteBatchExtensions.DrawCircleOutline(this.GetPosition(), this.GetRadius(), this.GetSegments(), this.GetColor());

        base.Draw(gameTime);
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