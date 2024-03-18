using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Library.Esliph.Components;

public interface IScriptMouseEvent
{
    public void OnMouseDown(MouseEvent keyEvent);
    public void OnMouseUp(MouseEvent keyEvent);
}

public class MouseEventController
{
    public MouseEventController(IScriptMouseEvent script) { }

    public static MouseEvent ReadMouseState()
    {
        MouseState mouseState = Mouse.GetState();

        return new(new(mouseState.X, mouseState.Y), mouseState.LeftButton, mouseState.MiddleButton, mouseState.RightButton);
    }
}

public class MouseEvent
{
    private float X, Y;
    private ButtonState[] buttons;
    public Vector2 position
    {
        get
        {
            return new(this.X, this.Y);
        }
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

    public MouseEvent(Vector2 position = new(), ButtonState leftButtons = ButtonState.Released, ButtonState middleButtons = ButtonState.Released, ButtonState rightButtons = ButtonState.Released)
    {
        this.buttons = new ButtonState[3];
        this.buttons[0] = leftButtons;
        this.buttons[1] = middleButtons;
        this.buttons[2] = rightButtons;
        this.X = position.X;
        this.Y = position.Y;
    }
}