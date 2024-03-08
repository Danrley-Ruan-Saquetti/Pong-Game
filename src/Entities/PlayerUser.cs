using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Pong.Entities;

public class PlayerUser : Player
{
    public PlayerUser() : base() { }
    public PlayerUser(float x) : base(x) { }
    public PlayerUser(int x) : base(x) { }

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