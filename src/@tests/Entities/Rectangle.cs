using System;
using Microsoft.Xna.Framework;
using Library.Esliph.Common;
using Library.Esliph.Shapes;
using Library.Esliph.Components;

namespace Test.Entities;

public class RectangleTestCollision : GameObject, IColliderComponentObject
{
    private float directionX;

    public RectangleTestCollision(int x, float directionX) : base()
    {
        this.directionX = directionX;
        this.AddComponents(
            new RectangleShape2D(new(x, 10 + (-directionX)), new(50 + (directionX * 5), 50 + (directionX * 5))),
            new RectangleCollider2DComponent(this)
        );

        this.GetShape2D().SetColor(Color.White);
    }

    public override void Update(GameTime gameTime)
    {
        this.GetShape2D().X += this.directionX;
        base.Update(gameTime);
    }

    public RectangleShape2D GetShape2D()
    {
        return this.GetShape2D<RectangleShape2D>();
    }

    public void OnCollisionEnter(IGameObject gameObject)
    {
        Console.WriteLine("OnCollisionEnter");
    }

    public void OnContainsEnter(IGameObject gameObject)
    {
        Console.WriteLine("OnContainsEnter");
    }

    public void OnContainsThisEnter(IGameObject gameObject)
    {
        Console.WriteLine("OnContainsThisEnter");
    }
}