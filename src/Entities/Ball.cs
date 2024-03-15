using Microsoft.Xna.Framework;
using Library.Esliph.Common;
using Pong.Global;
using Library.Esliph.Sprites;

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
            new CircleSprite(new(GameGlobals.WINDOW_DIMENSION.Width / 2, GameGlobals.WINDOW_DIMENSION.Height / 2),
            GameGlobals.BALL_RADIUS, null, 0, null, Color.White)
        );

        this.GetSprite().SetColor(Color.White);
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

        this.GetSprite().X += (int)(this.direction.X * deltaSpeed);
        this.GetSprite().Y += (int)(this.direction.Y * deltaSpeed);
    }

    public bool IsCollisionInBoard()
    {
        return this.GetSprite().InitialY < 0 || this.GetSprite().EndY > GameGlobals.WINDOW_DIMENSION.Height;
    }

    public void ToggleDirectionY()
    {
        this.direction.Y *= -1;
    }

    public Vector2 GetDirection()
    {
        return this.direction;
    }

    public CircleSprite GetSprite()
    {
        return this.GetSprite<CircleSprite>();
    }
}