using Microsoft.Xna.Framework;
using Library.Esliph.Common;
using Pong.Global;
using Library.Esliph.Sprite2Ds;

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
            new CircleSprite2D(new(GameGlobals.WINDOW_DIMENSION.Width / 2, GameGlobals.WINDOW_DIMENSION.Height / 2),
            GameGlobals.BALL_RADIUS, null, 0, null, Color.White)
        );

        this.GetSprite2D().SetColor(Color.White);
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

        this.GetSprite2D().X += (int)(this.direction.X * deltaSpeed);
        this.GetSprite2D().Y += (int)(this.direction.Y * deltaSpeed);
    }

    public bool IsCollisionInBoard()
    {
        return this.GetSprite2D().InitialY < 0 || this.GetSprite2D().EndY > GameGlobals.WINDOW_DIMENSION.Height;
    }

    public void ToggleDirectionY()
    {
        this.direction.Y *= -1;
    }

    public Vector2 GetDirection()
    {
        return this.direction;
    }

    public CircleSprite2D GetSprite2D()
    {
        return this.GetSprite2D<CircleSprite2D>();
    }
}