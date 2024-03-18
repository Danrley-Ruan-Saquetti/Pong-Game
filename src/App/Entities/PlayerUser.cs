using Library.Esliph.Components;
using Microsoft.Xna.Framework.Input;

namespace Pong.Entities;

public class PlayerUser : Player, IKeyEventComponentObject
{
    public PlayerUser(PlayerSide side) : this(side, 0) { }
    public PlayerUser(PlayerSide side, float x) : this(side, (int)x) { }
    public PlayerUser(PlayerSide side, int x) : base(side, x)
    {
        this.AddTags("User");
        this.AddComponents(new KeyEventComponent(this));
    }

    public void OnKeyDown(KeyEvent keyEvent)
    {
        if (keyEvent.IsEquals(Keys.W))
        {
            this.MoveUp();
        }
        else if (keyEvent.IsEquals(Keys.S))
        {
            this.MoveDown();
        }
    }

    public void OnKeyUp(KeyEvent keyEvent) { }
}