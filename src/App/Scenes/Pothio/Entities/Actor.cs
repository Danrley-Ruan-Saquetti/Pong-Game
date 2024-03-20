using Library.Esliph.Components.GameObjects;
using Library.Esliph.Utils;
using Microsoft.Xna.Framework;
using Pong.Global;

namespace Pong.Scenes.Pothio.Entities;

public class Actor : RectangleGameObject
{
    private int speed;

    public Actor(Vector2 position, Dimension dimension, int speed) : base(position, dimension)
    {
        this.speed = speed;
        this.AddTags("Actor");
    }

    public void MoveToRight()
    {
        this.GetShape2D().X += this.CalcDistanceMove();
    }

    public void MoveToLeft()
    {
        this.GetShape2D().X -= this.CalcDistanceMove();
    }

    public void MoveToDown()
    {
        this.GetShape2D().Y += this.CalcDistanceMove();
    }

    public void MoveToUp()
    {
        this.GetShape2D().Y -= this.CalcDistanceMove();
    }

    public int CalcDistanceMove()
    {
        return GlobalGame.CalcDistanceMove(this.speed, (float)this.gameController.GetGameTime().ElapsedGameTime.TotalSeconds);
    }

    public int GetSpeed()
    {
        return this.speed;
    }
}