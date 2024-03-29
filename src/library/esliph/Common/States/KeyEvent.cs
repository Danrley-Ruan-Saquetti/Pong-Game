using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace Library.Esliph.Common.Stats;

public enum KeyEventType
{
    NONE = 0,
    KEY_DOWN = 1,
    KEY_UP = 2,
}

public interface IKeyEvent
{
    public bool IsActive();
    public bool IsKeyUp(params Keys[] keys);
    public bool IsKeyDown(params Keys[] keys);
    public bool HasKey(Keys key);
    public KeyPressed GetKeyPressed(Keys key);
    public List<KeyPressed> GetKeyDownPressed();
    public List<KeyPressed> GetKeyUpPressed();
    public List<KeyPressed> GetPressedKeys();
}

public class KeyEvent : IKeyEvent
{
    private readonly List<KeyPressed> pressedKeys;

    public KeyEvent(List<KeyPressed> pressedKeys = null)
    {
        this.pressedKeys = pressedKeys ?? new();
    }

    public bool IsActive()
    {
        return this.GetPressedKeys().Count > 0;
    }

    public bool IsKeyUp(params Keys[] keys)
    {
        if (keys.Length == 0)
            return false;

        foreach (var key in keys)
            if (!this.HasKey(key) || !this.GetKeyPressed(key).IsKeyUp())
                return false;

        return true;
    }

    public bool IsKeyDown(params Keys[] keys)
    {
        if (keys.Length == 0)
            return false;

        foreach (var key in keys)
            if (!this.HasKey(key) || !this.GetKeyPressed(key).IsKeyDown())
                return false;

        return true;
    }

    public bool HasKey(Keys key)
    {
        return this.GetKeyPressed(key) != null;
    }

    public KeyPressed GetKeyPressed(Keys key)
    {
        return this.pressedKeys.Find(keyPressed => keyPressed.GetKey() == key);
    }

    public List<KeyPressed> GetKeyDownPressed()
    {
        return this.GetPressedKeys().Where(keyPressed => keyPressed.IsKeyDown()).ToList();
    }

    public List<KeyPressed> GetKeyUpPressed()
    {
        return this.GetPressedKeys().Where(keyPressed => keyPressed.IsKeyUp()).ToList();
    }

    public List<KeyPressed> GetPressedKeys()
    {
        return this.pressedKeys;
    }
}

public interface IKeyPressed
{
    public Keys GetKey();
    public KeyEventType GetKeyEventType();
    public bool IsKeyDown();
    public bool IsKeyUp();
}

public class KeyPressed : IKeyPressed
{
    private readonly Keys key;
    private readonly KeyEventType keyEventType;

    public KeyPressed(Keys key = Keys.None, KeyEventType keyEventType = KeyEventType.NONE)
    {
        this.key = key;
        this.keyEventType = keyEventType;
    }

    public Keys GetKey()
    {
        return this.key;
    }

    public KeyEventType GetKeyEventType()
    {
        return this.keyEventType;
    }

    public bool IsKeyDown()
    {
        return this.GetKeyEventType() == KeyEventType.KEY_DOWN;
    }

    public bool IsKeyUp()
    {
        return this.GetKeyEventType() == KeyEventType.KEY_UP;
    }
}