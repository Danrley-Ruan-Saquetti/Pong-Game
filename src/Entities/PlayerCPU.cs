using Microsoft.Xna.Framework;

namespace Pong.Entities;

public class PlayerCPU : Player
{
    private Ball ball { get; set; }

    public PlayerCPU(PlayerSide side) : base(side) { }
    public PlayerCPU(PlayerSide side, float x, Ball ball) : this(side, (int)x, ball) { }
    public PlayerCPU(PlayerSide side, int x, Ball ball) : base(side, x)
    {
        this.ball = ball;
        this.AddTags("CPU");
    }

    public override void Update(GameTime gameTime)
    {
        this.MovePlayer(gameTime);
    }

    public override void MovePlayer(GameTime gameTime)
    {
        if (this.IsTargetBallInThisPlayer())
        {
            this.MoveToBall(gameTime);
        }
        else
        {
            this.MoveToInitialPosition(gameTime);
        }
    }

    public void MoveToBall(GameTime gameTime)
    {
        int gap = (int)this.GetSprite().Height / 5;
        if (this.ball.GetSprite().InitialY < this.GetSprite().Y + gap)
        {
            this.MoveUp(gameTime);
        }
        else if (this.ball.GetSprite().EndY > this.GetSprite().Y + this.GetSprite().Height - gap)
        {
            this.MoveDown(gameTime);
        }
    }

    public bool IsTargetBallInThisPlayer()
    {
        return this.ball.GetDirection().X == (int)this.side;
    }

    public Ball GetBall()
    {
        return this.ball;
    }

    public void SetBall(Ball ball)
    {
        this.ball = ball;
    }
}