using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Library.Esliph.Components;

namespace Pong.Entities;

public class PlayerUser : Player
{
    public PlayerUser(PlayerSide side) : base(side)
    {
        this.AddTags("User");
    }
    public PlayerUser(PlayerSide side, float x) : base(side, x)
    {
        this.AddTags("User");
    }
    public PlayerUser(PlayerSide side, int x) : base(side, x)
    {
        this.AddTags("User");
    }

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