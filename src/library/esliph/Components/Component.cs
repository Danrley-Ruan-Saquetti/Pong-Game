using Library.Esliph.Common;
using Library.Esliph.Controller;

namespace Library.Esliph.Components;

public interface IComponent
{
    public void Start() { }
    public void Update(IGameObject gameObject) { }
    public bool IsActive();
    public void SetActive(bool active);
}

public class Component : IComponent
{
    protected GameController gameController = GameController.GetInstance();
    private bool active;

    public Component(bool active = true)
    {
        this.active = active;
    }

    public bool IsActive()
    {
        return this.active;
    }

    public void SetActive(bool active)
    {
        this.active = active;
    }
}