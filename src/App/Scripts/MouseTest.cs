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

    public void OnMouseStop(MouseEvent keyEvent)
    {
        WriteLine("OnMouseStop");
    }
    public void OnMouseClickUp(MouseEvent keyEvent)
    {
        WriteLine("OnMouseClickUp");
    }
}