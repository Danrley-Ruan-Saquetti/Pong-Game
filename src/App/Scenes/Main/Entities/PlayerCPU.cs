using Microsoft.Xna.Framework;

namespace Pong.Scenes.Main.Entities;

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

    public override void MovePlayer()
    {
        if (this.IsTargetBallInThisPlayer())
        {
            this.MoveToBall();
        }
        else
        {
            this.MoveToInitialPosition();
        }
    }

    public void MoveToBall()
    {
        int gap = (int)this.GetShape2D().Height / 5;
        if (this.ball.GetShape2D().InitialY < this.GetShape2D().Y + gap)
        {
            this.MoveUp();
        }
        else if (this.ball.GetShape2D().EndY > this.GetShape2D().Y + this.GetShape2D().Height - gap)
        {
            this.MoveDown();
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