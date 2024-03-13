using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Library.Esliph.Components;

namespace Pong.Entities;

public class PlayerUser : Player, IScriptKeyEvent
{
    public PlayerUser(PlayerSide side) : this(side, 0) { }
    public PlayerUser(PlayerSide side, float x) : this(side, (int)x) { }
    public PlayerUser(PlayerSide side, int x) : base(side, x)
    {
        this.AddTags("User");
        this.AddComponents(
            new KeyEventComponent(this)
        );
    }

    public void OnKeyDown(GameTime gameTime, KeyEvent keyEvent)
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

    public void OnKeyUp(GameTime gameTime, KeyEvent keyEvent) { }
}