using Microsoft.Xna.Framework;
using Library.Esliph.Sprites;
using Library.Esliph.Components;

namespace Library.Esliph.Common;

public interface IGameObject
{
    public ISprite GetSprite();
    public void Start();
    public void SetSprite(ISprite sprite);
    public void Update(GameTime gameTime);
    public void OnKeyDown(GameTime gameTime, KeyEvent keyEvent);
    public void OnKeyUp(GameTime gameTime, KeyEvent keyEvent);
    public void Draw(GameTime gameTime);
    public bool IsAlive();
    public void SetAlive(bool alive);
}
public interface IGameObject<T> where T : ISprite
{
    public T GetSprite();
    public void SetSprite(T sprite);
    public void Update(GameTime gameTime);
    public void OnKeyDown(GameTime gameTime, KeyEvent keyEvent);
    public void OnKeyUp(GameTime gameTime, KeyEvent keyEvent);
    public void Draw(GameTime gameTime);
    public bool IsAlive();
    public void SetAlive(bool alive);
}

public class GameObject<T> : IGameObject where T : ISprite
{
    private T sprite;
    private bool alive { get; set; }

    public GameObject(T sprite)
    {
        this.sprite = sprite;
        this.alive = true;
    }

    public virtual void Start() { }

    public virtual void Update(GameTime gameTime)
    {
        this.GetSprite().Update(gameTime);
    }

    public virtual void Draw(GameTime gameTime)
    {
        this.GetSprite().Draw(gameTime);
    }

    public virtual void OnKeyDown(GameTime gameTime, KeyEvent keyEvent) { }
    public virtual void OnKeyUp(GameTime gameTime, KeyEvent keyEvent) { }

    public T GetSprite()
    {
        return this.sprite;
    }

    public void SetSprite(ISprite sprite)
    {
        this.sprite = (T)sprite;
    }

    public bool IsAlive()
    {
        return alive;
    }

    public void SetAlive(bool alive)
    {
        this.alive = alive;
    }

    ISprite IGameObject.GetSprite()
    {
        return this.sprite;
    }
}