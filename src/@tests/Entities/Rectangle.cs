using Microsoft.Xna.Framework;
using Library.Esliph.Common;
using Library.Esliph.Sprite2Ds;

namespace Test.Entities;

public class RectangleTestCollision : GameObject
{
    private int directionX;

    public RectangleTestCollision(int x, int directionX) : base()
    {
        this.directionX = directionX;
        this.AddComponents(
            new RectangleSprite2D(new(x, 10 + directionX), new(50, 50))
        );
        this.GetSprite2D().SetColor(Color.White);
    }

    public override void Update(GameTime gameTime)
    {
        this.GetSprite2D().X += this.directionX;
        base.Update(gameTime);
    }

    public RectangleSprite2D GetSprite2D()
    {
        return this.GetSprite2D<RectangleSprite2D>();
    }
}