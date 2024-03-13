using System;
using Microsoft.Xna.Framework.Input;
using Library.Esliph.Components;
using Microsoft.Xna.Framework;

namespace Library.Esliph.Controllers;

public interface IScriptKeyEvent
{
    public void OnKeyDown(GameTime gameTime, KeyEvent keyEvent);
    public void OnKeyUp(GameTime gameTime, KeyEvent keyEvent);
}

public class KeyEventController
{
    private readonly IScriptKeyEvent script;

    public KeyEventController(IScriptKeyEvent script)
    {
        this.script = script;
    }

    public void ReadKeyboard(GameTime gameTime)
    {
        KeyEvent keyEvent = KeyEventController.ReadKeyboardState();

        if (!keyEvent.IsActive())
        {
            return;
        }

        if (keyEvent.IsKeyDown())
        {
            this.script.OnKeyDown(gameTime, keyEvent);
        }
        if (keyEvent.IsKeyUp())
        {
            this.script.OnKeyUp(gameTime, keyEvent);
        }
    }

    public static KeyEvent ReadKeyboardState()
    {
        KeyboardState keyboardState = Keyboard.GetState();

        if (keyboardState.GetPressedKeys().Length > 0)
        {
            Keys lastKeyPressed = keyboardState.GetPressedKeys()[0];

            if (keyboardState.IsKeyDown(lastKeyPressed))
            {
                return KeyEvent.KeyDown(lastKeyPressed, keyboardState.CapsLock, keyboardState.IsKeyDown(Keys.LeftShift) || keyboardState.IsKeyDown(Keys.RightShift));
            }

            if (keyboardState.IsKeyUp(lastKeyPressed))
            {
                return KeyEvent.KeyUp(lastKeyPressed, keyboardState.CapsLock, keyboardState.IsKeyUp(Keys.LeftShift) || keyboardState.IsKeyUp(Keys.RightShift));
            }
        }

        return new();
    }
}