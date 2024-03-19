using Library.Esliph.Common.Stats;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Library.Esliph.Controller;

public class MouseController
{
    private readonly static MouseController instance = new();
    private MouseEvent state = new();
    private bool isStoppedMove = true, isStoppedScroll = true;
    private bool[] buttonsPressed = { true, true, true };

    public MouseController() { }

    public static MouseController GetInstance()
    {
        return MouseController.instance;
    }

    public void Update()
    {
        this.ReadMouseState();
    }

    public void ReadMouseState()
    {
        MouseState mouseState = Mouse.GetState();

        this.state = new(
            mouseState.Position.ToVector2(),
            this.state.GetPosition(),
            mouseState.ScrollWheelValue,
            this.GetMouseEventScrollState(mouseState.ScrollWheelValue),
            this.GetMouseEventState(mouseState.Position.ToVector2()),
            this.GetMouseEventButtonState(mouseState.LeftButton, 0),
            this.GetMouseEventButtonState(mouseState.MiddleButton, 1),
            this.GetMouseEventButtonState(mouseState.RightButton, 2),
            this.state.GetClickLeft(),
            this.state.GetClickMiddle(),
            this.state.GetClickRight()
        );

        if (state.IsScrolled())
        {

        }
    }

    private MouseEventState GetMouseEventState(Vector2 position)
    {
        if (this.state.GetPosition() != position)
        {
            this.isStoppedMove = false;
            return MouseEventState.Move;
        }
        if (!this.isStoppedMove)
        {
            this.isStoppedMove = true;
            return MouseEventState.Stop;
        }

        return MouseEventState.None;
    }

    private MouseEventButtonState GetMouseEventButtonState(ButtonState buttonState, int index)
    {
        if (buttonState == ButtonState.Pressed)
        {
            this.buttonsPressed[index] = false;
            return MouseEventButtonState.Pressed;
        }
        if (!this.buttonsPressed[index])
        {
            this.buttonsPressed[index] = true;
            return MouseEventButtonState.Released;
        }

        return MouseEventButtonState.None;
    }

    private MouseEventScrollState GetMouseEventScrollState(int scrollValue)
    {
        if (scrollValue != 0)
        {
            this.isStoppedScroll = false;
            return MouseEventScrollState.Scroll;
        }
        if (!this.isStoppedScroll)
        {
            this.isStoppedScroll = true;
            return MouseEventScrollState.Stop;
        }

        return MouseEventScrollState.None;
    }

    public MouseEvent GetState()
    {
        return this.state;
    }
}