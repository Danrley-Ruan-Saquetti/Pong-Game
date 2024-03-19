using Microsoft.Xna.Framework.Input;
using Library.Esliph.Components;
using Library.Esliph.Common.Stats;

namespace Pong.Scenarios.Main.Entities;

public class PlayerUser : Player, IKeyEventComponentObject
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

    public void OnKeyDown(KeyEvent keyEvent)
    {
        if (keyEvent.IsKeyDown(Keys.W))
        {
            this.MoveUp();
        }
        else if (keyEvent.IsKeyDown(Keys.S))
        {
            this.MoveDown();
        }
    }
}