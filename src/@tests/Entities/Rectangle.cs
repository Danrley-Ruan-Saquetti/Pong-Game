using Microsoft.Xna.Framework;
using Library.Esliph.Common;
using Library.Esliph.Sprites;

namespace Test.Entities;

public class RectangleTestCollision : GameObject<RectangleSprite>
{
    private int directionX;

    public RectangleTestCollision(int x, int directionX) : base(new(new(x, 10 + directionX), new(50, 50)))
    {
        this.directionX = directionX;
        this.GetSprite().SetColor(Color.White);
    }

    public override void Update(GameTime gameTime)
    {
        this.GetSprite().X += this.directionX;
        base.Update(gameTime);
    }
}