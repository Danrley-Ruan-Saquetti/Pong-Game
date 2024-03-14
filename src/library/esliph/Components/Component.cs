using Microsoft.Xna.Framework;
using Library.Esliph.Common;
using Library.Esliph.Controller;

namespace Library.Esliph.Components;

public interface IComponent
{
    public void Start();
    public void Update(GameTime gameTime, IGameObject gameObject);
}
public interface IComponent<T> where T : IGameObject
{
    public void Start();
    public void Update(GameTime gameTime, T gameObject);
}

public class Component : IComponent
{
    protected GameController gameController = GameController.GetInstance();

    public virtual void Start() { }
    public virtual void Update(GameTime gameTime, IGameObject gameObject) { }
}
public class Component<T> : IComponent, IComponent<T> where T : IGameObject
{
    protected GameController gameController = GameController.GetInstance();

    public virtual void Start() { }
    public virtual void Update(GameTime gameTime, T gameObject) { }

    public void Update(GameTime gameTime, IGameObject gameObject) { }
}