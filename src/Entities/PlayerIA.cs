using Microsoft.Xna.Framework;

namespace Pong.Entities;

public class PlayerIA : Player
{
    private Ball ball { get; set; }

    public PlayerIA(PlayerSide side) : base(side) { }
    public PlayerIA(PlayerSide side, float x, Ball ball) : this(side, (int)x, ball) { }
    public PlayerIA(PlayerSide side, int x, Ball ball) : base(side, x)
    {
        this.ball = ball;
    }

    public override void Update(GameTime gameTime)
    {
        this.MovePlayer(gameTime);
        base.Update(gameTime);
    }

    public override void MovePlayer(GameTime gameTime)
    {

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