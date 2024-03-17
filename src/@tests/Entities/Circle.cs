using Microsoft.Xna.Framework;
using Library.Esliph.Common;
using Library.Esliph.Shapes;
using Library.Esliph.Components;
using System;
using Library.Esliph.Global;
using Pong.Global;

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

        Origin = new(GameGlobals.WINDOW_DIMENSION.Width / 2, GameGlobals.WINDOW_DIMENSION.Height / 2);
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

        if (circleShape2D.InitialX < 0 || circleShape2D.EndX > GameGlobals.WINDOW_DIMENSION.Width)
        {
            Direction.X *= -1;
        }
        if (circleShape2D.InitialY < 0 || circleShape2D.EndY > GameGlobals.WINDOW_DIMENSION.Height)
        {
            Direction.Y *= -1;
        }

        base.Update(gameTime);
    }

    private static Vector2 RandomPosition()
    {
        const int padding = 50;
        var x = _r.Next(padding, (int)GameGlobals.WINDOW_DIMENSION.Width - padding);
        var y = _r.Next(padding, (int)GameGlobals.WINDOW_DIMENSION.Height - padding);
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

    public void OnCollisionEnter(IGameObject gameObject)
    {
        var shape1 = this.GetShape2D();
        var shape2 = gameObject.GetShape2D<CircleShape2D>();

        var pos1 = shape1.GetPosition();
        var pos2 = shape2.GetPosition();

        var newDirection = pos1 - pos2;

        if (newDirection.X == 0 && newDirection.Y == 0)
        {
            return;
        }

        newDirection = Vector2.Normalize(newDirection);

        this.Direction = newDirection;
    }
}