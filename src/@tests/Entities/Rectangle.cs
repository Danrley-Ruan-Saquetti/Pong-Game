using Microsoft.Xna.Framework;
using Library.Esliph.Common;
using Library.Esliph.Shapes;

namespace Test.Entities;

public class RectangleTestCollision : GameObject
{
    private int directionX;

    public RectangleTestCollision(int x, int directionX) : base()
    {
        this.directionX = directionX;
        this.AddComponents(
            new RectangleShape2D(new(x, 10 + directionX), new(50, 50))
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
}