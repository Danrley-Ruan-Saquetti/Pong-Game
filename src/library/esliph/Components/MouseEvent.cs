using Library.Esliph.Common;
using Library.Esliph.Common.Stats;
using Library.Esliph.Controller;

namespace Library.Esliph.Components;

public interface IScriptMouseEvent : IGameObject
{
    public void OnMouseMove(IMouseEvent keyEvent) { }
    public void OnMouseStop(IMouseEvent keyEvent) { }
    public void OnMouseScroll(IMouseEvent keyEvent) { }
    public void OnMouseScrollStop(IMouseEvent keyEvent) { }
    public void OnMouseClickDown(IMouseEvent keyEvent) { }
    public void OnMouseClickUp(IMouseEvent keyEvent) { }
}

public class MouseEventComponent : Component
{
    protected MouseController mouseController;
    private readonly IScriptMouseEvent script;

    public MouseEventComponent(IScriptMouseEvent script) : base()
    {
        this.mouseController = MouseController.GetInstance();
        this.script = script;
    }

    public override void Update(IGameObject gameObject)
    {
        this.ResolveMouseEvent();
        base.Update(gameObject);
    }

    public void ResolveMouseEvent()
    {
        IMouseEvent mouseEvent = this.mouseController.GetState();

        if (mouseEvent.IsMove())
        {
            this.script.OnMouseMove(mouseEvent);
        }
        else
        if (mouseEvent.IsMoveStopped())
        {
            this.script.OnMouseStop(mouseEvent);
        }
        if (mouseEvent.HasClickDown())
        {
            this.script.OnMouseClickDown(mouseEvent);
        }
        if (mouseEvent.HasClickUp())
        {
            this.script.OnMouseClickUp(mouseEvent);
        }
        if (mouseEvent.IsScrolled())
        {
            this.script.OnMouseScroll(mouseEvent);
        }
        else
        if (mouseEvent.IsScrolledStop())
        {
            this.script.OnMouseScrollStop(mouseEvent);
        }
    }
}
