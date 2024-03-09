using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Pong.Entities;

public class PlayerUser : Player
{
    public PlayerUser(PlayerSide side) : base(side) { }
    public PlayerUser(PlayerSide side, float x) : base(side, x) { }
    public PlayerUser(PlayerSide side, int x) : base(side, x) { }

    public override void MovePlayer(GameTime gameTime)
    {
        KeyboardState keyboard = Keyboard.GetState();

        if (keyboard.IsKeyDown(Keys.W))
        {
            this.MoveUp(gameTime);
        }
        else if (keyboard.IsKeyDown(Keys.S))
        {
            this.MoveDown(gameTime);
        }
    }
}