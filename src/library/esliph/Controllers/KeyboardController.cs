using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Library.Esliph.Common.Stats;

namespace Library.Esliph.Controller;

public class KeyboardController
{
    private readonly static KeyboardController instance = new();
    private KeyEvent state;

    public KeyboardController() { }

    public static KeyboardController GetInstance()
    {
        return KeyboardController.instance;
    }

    public void Update()
    {
        this.ReadKeyboardState();
    }

    public void ReadKeyboardState()
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

        this.state = new(pressedKeys);
    }

    public KeyEvent GetState()
    {
        return this.state;
    }
}