using Microsoft.Xna.Framework;
using Library.Esliph.Common;

namespace Library.Esliph.Components;

public interface IComponent
{
    public void Start();
    public void Update(GameTime gameTime, IGameObject gameObject);
}

public class Component : IComponent
{
    public virtual void Start() { }
    public virtual void Update(GameTime gameTime, IGameObject gameObject) { }
}

public class Component<T> : Component
{
    protected readonly T componentObject;

    public Component(T componentObject)
    {
        this.componentObject = componentObject;
    }
}