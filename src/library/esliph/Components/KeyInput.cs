using Microsoft.Xna.Framework.Input;

namespace Library.Esliph.Components;

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