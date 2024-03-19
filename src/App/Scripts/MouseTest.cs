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

    // public void OnMouseMove(IMouseEvent mouseEvent)
    // {
    //     WriteLine("OnMouseMove");
    // }
    // public void OnMouseStop(IMouseEvent mouseEvent)
    // {
    //     WriteLine("OnMouseStop");
    // }
    // public void OnMouseScroll(IMouseEvent mouseEvent)
    // {
    //     WriteLine("OnMouseScroll");
    // }
    // public void OnMouseClickDown(IMouseEvent mouseEvent)
    // {
    //     WriteLine("OnMouseClickDown");
    // }
    // public void OnMouseClickUp(IMouseEvent mouseEvent)
    // {
    //     WriteLine("OnMouseClickUp");
    // }
}