using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Library.Esliph.Components;
using Library.Esliph.Controllers;

namespace Pong.Entities;

public class PlayerUser : Player, IScriptKeyEvent
{
    private KeyEventController keyEventController;

    public PlayerUser(PlayerSide side) : this(side, 0) { }
    public PlayerUser(PlayerSide side, float x) : this(side, (int)x) { }
    public PlayerUser(PlayerSide side, int x) : base(side, x)
    {
        this.keyEventController = new KeyEventController(this);
        this.AddTags("User");
    }

    public override void Update(GameTime gameTime)
    {
        this.keyEventController.ReadKeyboard(gameTime);
        base.Update(gameTime);
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