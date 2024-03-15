using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Library.Esliph.Common;

namespace Library.Esliph.Components;

<<<<<<< HEAD
public interface KeyEventComponentObject
=======
public interface IKeyEventComponentObject : IGameObject
>>>>>>> checkpoint
{
    public void OnKeyDown(GameTime gameTime, KeyEvent keyEvent);
    public void OnKeyUp(GameTime gameTime, KeyEvent keyEvent);
}

public class KeyEventComponent : Component
{
<<<<<<< HEAD
=======
    private IKeyEventComponentObject keyEventComponentObject;

    public KeyEventComponent(IKeyEventComponentObject keyEventComponentObject, bool active = true) : base(active)
    {
        this.keyEventComponentObject = keyEventComponentObject;
    }

>>>>>>> checkpoint
    public override void Update(GameTime gameTime, IGameObject gameObject)
    {
        KeyEvent keyEvent = KeyEventComponent.ReadKeyboardState();

        if (!keyEvent.IsActive())
        {
            return;
        }

<<<<<<< HEAD
        KeyEventComponentObject gameObjectKeyEvent = gameObject as KeyEventComponentObject;

=======
>>>>>>> checkpoint
        if (keyEvent.IsKeyDown())
        {
            this.keyEventComponentObject.OnKeyDown(gameTime, keyEvent);
        }
        if (keyEvent.IsKeyUp())
        {
            this.keyEventComponentObject.OnKeyUp(gameTime, keyEvent);
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

public enum KeyEventType
{
    NONE = 0,
    KEY_DOWN = 1,
    KEY_UP = 2,
}

public class KeyEvent
{
    private readonly Keys key;
    private readonly bool capsLock, shiftPress;
    private readonly KeyEventType keyEventType;

    public KeyEvent(Keys key = Keys.None, KeyEventType keyEventType = KeyEventType.NONE, bool capsLock = false, bool shiftPress = false)
    {
        this.key = key;
        this.keyEventType = keyEventType;
        this.capsLock = capsLock;
        this.shiftPress = shiftPress;
    }

    public static KeyEvent KeyDown(Keys key, bool capsLock = false, bool shiftPress = false)
    {
        return new(key, KeyEventType.KEY_DOWN, capsLock, shiftPress);
    }

    public static KeyEvent KeyUp(Keys key, bool capsLock = false, bool shiftPress = false)
    {
        return new(key, KeyEventType.KEY_UP, capsLock, shiftPress);
    }

    public bool IsEquals(Keys key)
    {
        return this.GetKey() == key;
    }

    public bool IsKeyDown()
    {
        return this.GetKeyEventType() == KeyEventType.KEY_DOWN;
    }

    public bool IsKeyUp()
    {
        return this.GetKeyEventType() == KeyEventType.KEY_UP;
    }

    public bool IsActive()
    {
        return this.GetKeyEventType() != KeyEventType.NONE;
    }

    public Keys GetKey()
    {
        return this.key;
    }

    public bool IsShiftPressed()
    {
        return this.shiftPress;
    }

    public bool IsCapsLock()
    {
        return this.capsLock;
    }

    public KeyEventType GetKeyEventType()
    {
        return this.keyEventType;
    }
}