using Microsoft.Xna.Framework.Input;
using Library.Esliph.Common;
using Library.Esliph.Common.Stats;
using System.Collections.Generic;

namespace Library.Esliph.Components;

public interface IKeyEventComponentObject : IGameObject
{
    public void OnKeyDown(KeyEvent keyEvent) { }
    public void OnKeyUp(KeyEvent keyEvent) { }
}

public class KeyEventComponent : Component
{
    private IKeyEventComponentObject keyEventComponentObject;

    public KeyEventComponent(IKeyEventComponentObject keyEventComponentObject, bool active = true) : base(active)
    {
        this.keyEventComponentObject = keyEventComponentObject;
    }

    public override void Update(IGameObject gameObject)
    {
        KeyEvent keyEvent = KeyEventComponent.ReadKeyboardState();

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

        base.Update(gameObject);
    }

    public static KeyEvent ReadKeyboardState()
    {
        KeyboardState keyboardState = Keyboard.GetState();

        List<KeyPressed> pressedKeys = new();
        var _pressedKeys = keyboardState.GetPressedKeys();

        foreach (var _keyPressed in _pressedKeys)
        {
            var type = keyboardState.IsKeyDown(_keyPressed) ? KeyEventType.KEY_DOWN : keyboardState.IsKeyUp(_keyPressed) ? KeyEventType.KEY_UP : KeyEventType.NONE;

            KeyPressed keyPressed = new(_keyPressed, type);

            pressedKeys.Add(keyPressed);
        }

        return new(pressedKeys);
    }
}