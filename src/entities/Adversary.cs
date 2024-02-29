using Microsoft.Xna.Framework;
using Pong.Global;

namespace Pong.Entities;

public class Adversary : PlayerModel
{
    public Adversary(int x, int y) : base(x, y) { }

    public override void Update(GameTime gameTime)
    {
        this.FollowTarget(this.ball.rectangle.Y + (this.ball.rectangle.Height / 2), (float)gameTime.ElapsedGameTime.TotalSeconds);
        base.Update(gameTime);
    }
}