using Library.Esliph.Common;
using Library.Esliph.Common.Stats;
using Library.Esliph.Controller;

namespace Library.Esliph.Components;

public interface IKeyEventComponentObject : IGameObject
{
    public void OnKeyDown(KeyEvent keyEvent) { }
    public void OnKeyUp(KeyEvent keyEvent) { }
}

public class KeyEventComponent : Component
{
    private IKeyEventComponentObject keyEventComponentObject;
    private KeyboardController keyboardController;

    public KeyEventComponent(IKeyEventComponentObject keyEventComponentObject, bool active = true) : base(active)
    {
        this.keyEventComponentObject = keyEventComponentObject;
        this.keyboardController = KeyboardController.GetInstance();
    }

    public override void Update(IGameObject gameObject)
    {
        this.ResolveKeyEvent();
        base.Update(gameObject);
    }

    public void ResolveKeyEvent()
    {
        KeyEvent keyEvent = this.keyboardController.GetState();

        if (!keyEvent.IsActive())
        {
            return;
        }

        if (keyEvent.GetKeyDownPressed().Count > 0)
        {
            this.keyEventComponentObject.OnKeyDown(keyEvent);
        }
        if (keyEvent.GetKeyUpPressed().Count > 0)
        {
            this.keyEventComponentObject.OnKeyUp(keyEvent);
        }
    }
}