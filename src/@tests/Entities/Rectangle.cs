using Microsoft.Xna.Framework;
using Library.Esliph.Common;
using Library.Esliph.Sprites;
using Library.Esliph.Components;
using System;

namespace Test.Entities;

public class RectangleTestCollision : GameObject<RectangleSprite>, IRectangleColliderComponentObject
{
    private int directionX;

    public RectangleTestCollision(int x, int directionX) : base(new(new(x, 10 + directionX), new(50, 50)))
    {
        this.directionX = directionX;
        this.GetSprite().SetColor(Color.White);
        this.AddComponents(
            new RectangleColliderComponent()
        );
    }

    public override void Update(GameTime gameTime)
    {
        this.GetSprite().X += this.directionX;
        base.Update(gameTime);
    }

    public void OnCollision()
    {
        Console.WriteLine("Collide");
    }
}