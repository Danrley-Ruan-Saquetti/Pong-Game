using Microsoft.Xna.Framework;
using Library.Esliph.Common;
using Library.Esliph.Shapes;
using Library.Esliph.Components;
using System;
using Library.Esliph.Global;

namespace Test.Entities;

public class CircleTestCollision : GameObject
{
    private float directionX;

    public CircleTestCollision(int x, float directionX) : base()
    {
        this.directionX = directionX;
        this.AddComponents(
            new CircleShape2D(new(x, 30), 20, null, 0, null, Color.White)
        );

        this.GetShape2D().SetColor(Color.White);
    }

    public override void Update(GameTime gameTime)
    {
        this.GetShape2D().X += this.directionX;
        base.Update(gameTime);
    }

    public CircleShape2D GetShape2D()
    {
        return this.GetShape2D<CircleShape2D>();
    }
}

public class CircleTestCollision1 : GameObject, IColliderComponentObject
{
    private static readonly Random _r = new();
    public Vector2 Origin { get; }
    public Vector2 Direction;
    public int Speed;

    public CircleTestCollision1() : base()
    {
        this.AddComponents(
            new CircleShape2D(),
            new CircleCollider2DComponent(this)
        );

        Origin = new(Globals.WINDOW_DIMENSION.Width / 2, Globals.WINDOW_DIMENSION.Height / 2);
        Speed = 200;
        Direction = RandomDirection();
        ICircleShape2D circleShape2D = this.GetShape2D();
        circleShape2D.SetPosition(RandomPosition());
        circleShape2D.SetColor(Color.White);
        circleShape2D.SetRadius(20);
    }

    public override void Update(GameTime gameTime)
    {
        CircleShape2D circleShape2D = this.GetShape2D();

        circleShape2D.SetPosition(circleShape2D.GetPosition() + Direction * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds);

        if (circleShape2D.InitialX < 0 || circleShape2D.InitialX > Globals.WINDOW_DIMENSION.Width)
        {
            Direction.X *= -1;
        }
        if (circleShape2D.InitialY < 0 || circleShape2D.InitialY > Globals.WINDOW_DIMENSION.Height)
        {
            Direction.Y *= -1;
        }

        circleShape2D.SetPosition(new(MathHelper.Clamp(circleShape2D.X, Origin.X, Globals.WINDOW_DIMENSION.Width - Origin.X),
                       MathHelper.Clamp(circleShape2D.Y, Origin.Y, Globals.WINDOW_DIMENSION.Height - Origin.Y)));

        base.Update(gameTime);
    }

    private static Vector2 RandomPosition()
    {
        const int padding = 50;
        var x = _r.Next(padding, (int)Globals.WINDOW_DIMENSION.Width - padding);
        var y = _r.Next(padding, (int)Globals.WINDOW_DIMENSION.Height - padding);
        return new(x, y);
    }

    private static Vector2 RandomDirection()
    {
        var angle = _r.NextDouble() * 2 * Math.PI;
        return new((float)Math.Sin(angle), -(float)Math.Cos(angle));
    }

    public CircleShape2D GetShape2D()
    {
        return this.GetShape2D<CircleShape2D>();
    }

    public void OnCollisionEnter(IGameObject gameObject) { }
    public void OnContainsEnter(IGameObject gameObject) { }
    public void OnContainsThisEnter(IGameObject gameObject) { }
}