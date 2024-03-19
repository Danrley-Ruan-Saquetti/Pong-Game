using Library.Esliph.Common.Stats;
using Library.Esliph.Components;

namespace Pong.Scripts;

public class MouseTest : GeneralScript, IScriptMouseEvent
{
    public MouseTest() : base()
    {
        this.AddComponents(
            new MouseEventComponent(this)
        );
    }

    public void OnMouseMove(MouseEvent mouseEvent)
    {
        WriteLine("OnMouseMove");
    }
    public void OnMouseStop(MouseEvent mouseEvent)
    {
        WriteLine("OnMouseStop");
    }
    public void OnMouseScroll(MouseEvent mouseEvent)
    {
        WriteLine("OnMouseScroll");
    }
    public void OnMouseClickDown(MouseEvent mouseEvent)
    {
        WriteLine("OnMouseClickDown");
    }
    public void OnMouseClickUp(MouseEvent mouseEvent)
    {
        WriteLine("OnMouseClickUp");
    }
}