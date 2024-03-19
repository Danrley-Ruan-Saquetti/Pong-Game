using Microsoft.Xna.Framework;

namespace Library.Esliph.Common.Stats;

public enum MouseEventButtonState
{
    Released,
    Pressed,
    None
}

public enum MouseEventState
{
    None,
    Move,
    Stop
}

public interface IMouseEvent
{

}

public class MouseEvent : IMouseEvent
{
    private readonly MouseEventButtonState[] buttons, lastButtons;
    private readonly Vector2 position, previousPosition;
    private readonly int previousScrollWheelValue, scrollWheelValue;
    private readonly MouseEventState mouseState;
    private float X { get { return this.position.X; } }
    private float Y { get { return this.position.Y; } }
    private MouseEventButtonState leftButton { get { return this.buttons[0]; } }
    private MouseEventButtonState middleButton { get { return this.buttons[1]; } }
    private MouseEventButtonState rightButton { get { return this.buttons[2]; } }
    private MouseEventButtonState lastLeftButton { get { return this.lastButtons[0]; } }
    private MouseEventButtonState lastMiddleButton { get { return this.lastButtons[1]; } }
    private MouseEventButtonState lastRightButton { get { return this.lastButtons[2]; } }

    public MouseEvent(
        Vector2 position = new(),
        Vector2 previousPosition = new(),
        int scrollWheelValue = 0,
        int previousScrollWheelValue = 0,
        MouseEventState mouseState = MouseEventState.None,
        MouseEventButtonState leftButton = MouseEventButtonState.Released,
        MouseEventButtonState middleButton = MouseEventButtonState.Released,
        MouseEventButtonState rightButton = MouseEventButtonState.Released,
        MouseEventButtonState LastLeftButton = MouseEventButtonState.Released,
        MouseEventButtonState LastMiddleButton = MouseEventButtonState.Released,
        MouseEventButtonState LastRightButton = MouseEventButtonState.Released
    )
    {
        this.position = position;
        this.mouseState = position != previousPosition ? MouseEventState.Move : mouseState;
        this.scrollWheelValue = scrollWheelValue;
        this.previousPosition = previousPosition;
        this.previousScrollWheelValue = previousScrollWheelValue;
        this.buttons = new MouseEventButtonState[3];
        this.lastButtons = new MouseEventButtonState[3];
        this.buttons[0] = leftButton;
        this.buttons[1] = middleButton;
        this.buttons[2] = rightButton;
        this.lastButtons[0] = LastLeftButton;
        this.lastButtons[1] = LastMiddleButton;
        this.lastButtons[2] = LastRightButton;
    }

    public bool IsMove()
    {
        return this.mouseState == MouseEventState.Move;
    }

    public bool IsStopped()
    {
        return this.mouseState == MouseEventState.Stop;
    }

    public MouseEventState GetMouseState()
    {
        return this.mouseState;
    }

    public Vector2 DiferencePosition()
    {
        return this.previousPosition - this.position;
    }

    public Vector2 GetPosition()
    {
        return this.position;
    }

    public Vector2 GetLastPosition()
    {
        return this.previousPosition;
    }

    public bool HasClickDown()
    {
        return this.IsClickDownLeft() || this.IsClickDownMiddle() || this.IsClickDownRight();
    }

    public bool IsClickDownLeft()
    {
        return this.leftButton == MouseEventButtonState.Pressed;
    }

    public bool IsClickDownRight()
    {
        return this.rightButton == MouseEventButtonState.Pressed;
    }

    public bool IsClickDownMiddle()
    {
        return this.middleButton == MouseEventButtonState.Pressed;
    }

    public bool HasClickUp()
    {
        return this.IsClickUpLeft() || this.IsClickUpMiddle() || this.IsClickUpRight();
    }

    public bool IsClickUpLeft()
    {
        return this.leftButton == MouseEventButtonState.Released;
    }

    public bool IsClickUpRight()
    {
        return this.rightButton == MouseEventButtonState.Released;
    }

    public bool IsClickUpMiddle()
    {
        return this.middleButton == MouseEventButtonState.Released;
    }

    public MouseEventButtonState GetClickLeft()
    {
        return this.leftButton;
    }

    public MouseEventButtonState GetClickRight()
    {
        return this.rightButton;
    }

    public MouseEventButtonState GetClickMiddle()
    {
        return this.middleButton;
    }

    public MouseEventButtonState GetLastClickLeft()
    {
        return this.lastLeftButton;
    }

    public MouseEventButtonState GetLastClickRight()
    {
        return this.lastRightButton;
    }

    public MouseEventButtonState GetClick(int index)
    {
        return this.buttons[index];
    }

    public MouseEventButtonState GetLastClick(int index)
    {
        return this.lastButtons[index];
    }

    public MouseEventButtonState GetLastClickMiddle()
    {
        return this.lastMiddleButton;
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