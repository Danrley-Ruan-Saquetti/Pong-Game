using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Library.Esliph.Common;

namespace Library.Esliph.Components;

public interface IScriptKeyEvent
{
    public void OnKeyDown(GameTime gameTime, KeyEvent keyEvent);
    public void OnKeyUp(GameTime gameTime, KeyEvent keyEvent);
}

public class KeyEventComponent : Component
{
    private readonly IScriptKeyEvent script;

    public KeyEventComponent(IScriptKeyEvent script) : base()
    {
        this.script = script;
    }

    public override void Update(GameTime gameTime, IGameObject gameObject)
    {
        KeyEvent keyEvent = KeyEventComponent.ReadKeyboardState();

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