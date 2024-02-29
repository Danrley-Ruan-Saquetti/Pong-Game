using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Pong.Entities;

public class Player : PlayerModel
{
    public Player(int x, int y) : base(x, y) { }

    public override void Update(GameTime gameTime)
    {
        this.FollowTarget(this.ball.GetBounds().PointCenterY, (float)gameTime.ElapsedGameTime.TotalSeconds);
        // this.MovePlayer(gameTime.ElapsedGameTime.TotalSeconds);
        base.Update(gameTime);
    }

    public void MovePlayer(double totalSecondsGameTime)
    {
        KeyboardState keyboard = Keyboard.GetState();

        if (keyboard.IsKeyDown(Keys.W))
        {
            this.MoveUp(totalSecondsGameTime);
        }
        else if (keyboard.IsKeyDown(Keys.S))
        {
            this.MoveDown(totalSecondsGameTime);
        }
    }
}