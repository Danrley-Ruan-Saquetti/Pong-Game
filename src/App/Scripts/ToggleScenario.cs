using Microsoft.Xna.Framework.Input;
using Library.Esliph.Components;
using Library.Esliph.Common.Stats;

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
        if (keyEvent.IsKeyDown(Keys.LeftShift, Keys.D1))
            this.gameController.ToggleScenario("Main");
        else if (keyEvent.IsKeyDown(Keys.D2))
            this.gameController.ToggleScenario("Rotation");
    }
}