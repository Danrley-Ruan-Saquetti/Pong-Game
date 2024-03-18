using Library.Esliph.Components;
using Microsoft.Xna.Framework.Input;

namespace Pong.Scripts;

public class ToggleScenarioScript : GeneralScript, IKeyEventComponentObject
{
    public ToggleScenarioScript() : base()
    {
        this.AddComponents(
            new KeyEventComponent(this)
        );
    }

    public void OnKeyDown(KeyEvent keyEvent)
    {
        if (keyEvent.GetKey() == Keys.D1)
            this.gameController.ToggleScenario("Main");
        else if (keyEvent.GetKey() == Keys.D2)
            this.gameController.ToggleScenario("Rotation");
    }
}