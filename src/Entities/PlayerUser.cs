using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Library.Esliph.Components;

namespace Pong.Entities;

public class PlayerUser : Player
{
    public PlayerUser(PlayerSide side) : base(side) { }
    public PlayerUser(PlayerSide side, float x) : base(side, x) { }
    public PlayerUser(PlayerSide side, int x) : base(side, x) { }

    public override void OnKeyDown(GameTime gameTime, KeyEvent keyEvent)
    {
        if (keyEvent.IsEquals(Keys.W))
        {
            this.MoveUp(gameTime);
        }
        else if (keyEvent.IsEquals(Keys.S))
        {
            this.MoveDown(gameTime);
        }
    }
}