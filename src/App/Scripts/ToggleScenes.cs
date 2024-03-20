using Microsoft.Xna.Framework.Input;
using Library.Esliph.Components;
using Library.Esliph.Common.Stats;

namespace Pong.Scripts;

public class ToggleSceneScript : GeneralScript, IKeyEventComponentObject
{
    public ToggleSceneScript() : base()
    {
        this.AddComponents(
            new KeyEventComponent(this)
        );
    }

    public void OnKeyDown(KeyEvent keyEvent)
    {
        if (keyEvent.IsKeyDown(Keys.D1))
            this.gameController.ToggleScene("Main");
        else if (keyEvent.IsKeyDown(Keys.D2))
            this.gameController.ToggleScene("Rotation");
    }
}