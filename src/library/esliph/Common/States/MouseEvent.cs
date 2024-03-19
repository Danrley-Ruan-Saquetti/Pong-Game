using Microsoft.Xna.Framework;

namespace Library.Esliph.Common.Stats;

public enum MouseEventState
{
    None,
    Move,
    Stop
}

public enum MouseEventScrollState
{
    None,
    Scroll,
    Stop
}

public enum MouseEventButtonState
{
    Released,
    Pressed,
    None
}

public interface IMouseEvent
{
    public bool IsMove();
    public bool IsMoveStopped();
    public MouseEventState GetMouseState();
    public Vector2 DiferencePosition();
    public Vector2 GetPosition();
    public Vector2 GetLastPosition();
    public bool HasClickDown();
    public bool IsClickDownLeft();
    public bool IsClickDownRight();
    public bool IsClickDownMiddle();
    public bool HasClickUp();
    public bool IsClickUpLeft();
    public bool IsClickUpRight();
    public bool IsClickUpMiddle();
    public MouseEventButtonState GetClickLeft();
    public MouseEventButtonState GetClickRight();
    public MouseEventButtonState GetClickMiddle();
    public MouseEventButtonState GetLastClickLeft();
    public MouseEventButtonState GetLastClickRight();
    public MouseEventButtonState GetClick(int index);
    public MouseEventButtonState GetLastClick(int index);
    public MouseEventButtonState GetLastClickMiddle();
    public bool IsScrolled();
    public bool IsScrolledStop();
    public int GetScrollValue();
}

public class MouseEvent : IMouseEvent
{
    private readonly MouseEventButtonState[] buttons, lastButtons;
    private readonly Vector2 position, previousPosition;
    private readonly int scrollWheelValue;
    private readonly MouseEventState mouseState;
    private readonly MouseEventScrollState scrollState;
    private MouseEventButtonState leftButtonState { get { return this.buttons[0]; } }
    private MouseEventButtonState middleButtonState { get { return this.buttons[1]; } }
    private MouseEventButtonState rightButtonState { get { return this.buttons[2]; } }
    private MouseEventButtonState lastLeftButtonState { get { return this.lastButtons[0]; } }
    private MouseEventButtonState lastMiddleButtonState { get { return this.lastButtons[1]; } }
    private MouseEventButtonState lastRightButtonState { get { return this.lastButtons[2]; } }
    private float X { get { return this.position.X; } }
    private float Y { get { return this.position.Y; } }

    public MouseEvent(
        Vector2 position = new(),
        Vector2 previousPosition = new(),
        int scrollWheelValue = 0,
        MouseEventScrollState scrollState = MouseEventScrollState.None,
        MouseEventState mouseState = MouseEventState.None,
        MouseEventButtonState leftButtonState = MouseEventButtonState.Released,
        MouseEventButtonState middleButtonState = MouseEventButtonState.Released,
        MouseEventButtonState rightButtonState = MouseEventButtonState.Released,
        MouseEventButtonState LastLeftButton = MouseEventButtonState.Released,
        MouseEventButtonState LastMiddleButtonState = MouseEventButtonState.Released,
        MouseEventButtonState LastRightButton = MouseEventButtonState.Released
    )
    {
        this.position = position;
        this.mouseState = position != previousPosition ? MouseEventState.Move : mouseState;
        this.scrollState = scrollState;
        this.scrollWheelValue = scrollWheelValue;
        this.previousPosition = previousPosition;
        this.buttons = new MouseEventButtonState[3];
        this.lastButtons = new MouseEventButtonState[3];
        this.buttons[0] = leftButtonState;
        this.buttons[1] = middleButtonState;
        this.buttons[2] = rightButtonState;
        this.lastButtons[0] = LastLeftButton;
        this.lastButtons[1] = LastMiddleButtonState;
        this.lastButtons[2] = LastRightButton;
    }

    public bool IsMove()
    {
        return this.mouseState == MouseEventState.Move;
    }

    public bool IsMoveStopped()
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
        return this.leftButtonState == MouseEventButtonState.Pressed;
    }

    public bool IsClickDownRight()
    {
        return this.rightButtonState == MouseEventButtonState.Pressed;
    }

    public bool IsClickDownMiddle()
    {
        return this.middleButtonState == MouseEventButtonState.Pressed;
    }

    public bool HasClickUp()
    {
        return this.IsClickUpLeft() || this.IsClickUpMiddle() || this.IsClickUpRight();
    }

    public bool IsClickUpLeft()
    {
        return this.leftButtonState == MouseEventButtonState.Released;
    }

    public bool IsClickUpRight()
    {
        return this.rightButtonState == MouseEventButtonState.Released;
    }

    public bool IsClickUpMiddle()
    {
        return this.middleButtonState == MouseEventButtonState.Released;
    }

    public MouseEventButtonState GetClickLeft()
    {
        return this.leftButtonState;
    }

    public MouseEventButtonState GetClickRight()
    {
        return this.rightButtonState;
    }

    public MouseEventButtonState GetClickMiddle()
    {
        return this.middleButtonState;
    }

    public MouseEventButtonState GetLastClickLeft()
    {
        return this.lastLeftButtonState;
    }

    public MouseEventButtonState GetLastClickRight()
    {
        return this.lastRightButtonState;
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
        return this.lastMiddleButtonState;
    }

    public bool IsScrolled()
    {
        return this.scrollState == MouseEventScrollState.Scroll;
    }

    public bool IsScrolledStop()
    {
        return this.scrollState == MouseEventScrollState.Stop;
    }

    public int GetScrollValue()
    {
        return this.scrollWheelValue;
    }
}