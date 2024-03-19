using Library.Esliph.Common;
using Library.Esliph.Common.Stats;
using Library.Esliph.Controller;

namespace Library.Esliph.Components;

public interface IScriptMouseEvent : IGameObject
{
    public void OnMouseMove(MouseEvent keyEvent) { }
    public void OnMouseStop(MouseEvent keyEvent) { }
    public void OnMouseScroll(MouseEvent keyEvent) { }
    public void OnMouseScrollStop(MouseEvent keyEvent) { }
    public void OnMouseClickDown(MouseEvent keyEvent) { }
    public void OnMouseClickUp(MouseEvent keyEvent) { }
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
        MouseEvent mouseEvent = this.mouseController.GetState();

        if (mouseEvent.IsMove())
        {
            this.script.OnMouseMove(mouseEvent);
        }
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
        if (mouseEvent.IsScrolledStop())
        {
            this.script.OnMouseScrollStop(mouseEvent);
        }
    }
}
