using Library.Esliph.Common.Stats;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Library.Esliph.Controller;

public class MouseController
{
    private readonly static MouseController instance = new();
    private MouseEvent state = new();
    private Vector2 previousMousePosition = new();
    private int previousScrollWheelValue = 0;

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

        this.state = new(this.previousMousePosition, mouseState.Position.ToVector2(), mouseState.LeftButton, mouseState.MiddleButton, mouseState.RightButton, this.previousScrollWheelValue, mouseState.ScrollWheelValue);

        if (state.IsMove())
        {
            this.previousMousePosition = mouseState.Position.ToVector2();
        }
        if (state.IsScrolled())
        {
            this.previousScrollWheelValue = mouseState.ScrollWheelValue;
        }
    }

    public MouseEvent GetState()
    {
        return this.state;
    }
}