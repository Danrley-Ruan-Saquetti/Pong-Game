using Microsoft.Xna.Framework;
using Library.Esliph.Common;
using Pong.Global;
using Library.Esliph.Shapes;

namespace Pong.Entities;

public class Ball : GameObject
{
    private float speed { get; set; }
    private Vector2 direction;

    public Ball() : base()
    {
        this.direction = new(1, 1);
        this.speed = GameGlobals.BALL_SPEED;
        this.AddTags("Entity", "Ball");
        this.AddComponents(
            new CircleShape2D(new(GameGlobals.WINDOW_DIMENSION.Width / 2, GameGlobals.WINDOW_DIMENSION.Height / 2),
            GameGlobals.BALL_RADIUS, null, 0, null, Color.White)
        );

        this.GetShape2D().SetColor(Color.White);
    }

    public override void Update(GameTime gameTime)
    {
        if (this.IsCollisionInBoard())
        {
            this.ToggleDirectionY();
        }
        this.MoveBall(gameTime);
        base.Update(gameTime);
    }

    public void MoveBall(GameTime gameTime)
    {
        float deltaSpeed = this.speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

        this.GetShape2D().X += (int)(this.direction.X * deltaSpeed);
        this.GetShape2D().Y += (int)(this.direction.Y * deltaSpeed);
    }

    public bool IsCollisionInBoard()
    {
        return this.GetShape2D().InitialY < 0 || this.GetShape2D().EndY > GameGlobals.WINDOW_DIMENSION.Height;
    }

    public void ToggleDirectionY()
    {
        this.direction.Y *= -1;
    }

    public Vector2 GetDirection()
    {
        return this.direction;
    }

    public CircleShape2D GetShape2D()
    {
        return this.GetShape2D<CircleShape2D>();
    }
}