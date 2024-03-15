using Microsoft.Xna.Framework;
using Library.Esliph.Common;
using Library.Esliph.Sprites;

namespace Test.Entities;

public class RectangleTestCollision : GameObject
{
    private int directionX;

    public RectangleTestCollision(int x, int directionX) : base()
    {
        this.directionX = directionX;
        this.AddComponents(
            new RectangleSprite(new(x, 10 + directionX), new(50, 50))
        );
        this.GetSprite().SetColor(Color.White);
    }

    public override void Update(GameTime gameTime)
    {
        this.GetSprite().X += this.directionX;
        base.Update(gameTime);
    }

    public RectangleSprite GetSprite()
    {
        return this.GetSprite<RectangleSprite>();
    }
}