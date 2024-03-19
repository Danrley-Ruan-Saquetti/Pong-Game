using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Library.Esliph.Common.Stats;

public class MouseEvent
{
    private ButtonState[] buttons;
    public readonly Vector2 position, previousPosition;
    private int previousScrollWheelValue, scrollWheelValue;
    private float X
    {
        get { return this.position.X; }
    }
    private float Y
    {
        get { return this.position.Y; }
    }
    public ButtonState leftButtons
    {
        get
        {
            return this.buttons[0];
        }
    }
    public ButtonState middleButtons
    {
        get
        {
            return this.buttons[1];
        }
    }
    public ButtonState rightButtons
    {
        get
        {
            return this.buttons[2];
        }
    }

    public MouseEvent(Vector2 previousPosition = new(), Vector2 position = new(), ButtonState leftButtons = ButtonState.Released, ButtonState middleButtons = ButtonState.Released, ButtonState rightButtons = ButtonState.Released, int previousScrollWheelValue = 0, int scrollWheelValue = 0)
    {
        this.previousPosition = previousPosition;
        this.position = position;
        this.buttons = new ButtonState[3];
        this.buttons[0] = leftButtons;
        this.buttons[1] = middleButtons;
        this.buttons[2] = rightButtons;
        this.previousScrollWheelValue = previousScrollWheelValue;
        this.scrollWheelValue = scrollWheelValue;
    }

    public bool IsMove()
    {
        return this.position != this.previousPosition;
    }

    public Vector2 DiferencePosition()
    {
        return this.previousPosition - this.position;
    }

    public bool IsClickLeft()
    {
        return this.leftButtons == ButtonState.Pressed;
    }

    public bool IsClickRight()
    {
        return this.rightButtons == ButtonState.Pressed;
    }

    public bool IsClickMiddle()
    {
        return this.middleButtons == ButtonState.Pressed;
    }

    public Vector2 GetPosition()
    {
        return this.position;
    }

    public Vector2 GetLastPosition()
    {
        return this.previousPosition;
    }

    public bool IsScrolled()
    {
        return this.DiferenceScrollValue() != 0;
    }

    public int DiferenceScrollValue()
    {
        return this.previousScrollWheelValue - this.scrollWheelValue;
    }

    public int GetScrollValue()
    {
        return this.scrollWheelValue;
    }

    public int GetLastScrollValue()
    {
        return this.previousScrollWheelValue;
    }
}