using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Library.Esliph.Components;

namespace Library.Esliph.Controllers;

public interface IScriptMouseEvent
{
    public void OnMouseDown(GameTime gameTime, MouseEvent keyEvent);
    public void OnMouseUp(GameTime gameTime, MouseEvent keyEvent);
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