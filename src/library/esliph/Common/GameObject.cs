using Microsoft.Xna.Framework;
using Library.Esliph.Sprites;

namespace Library.Esliph.Common;

public interface IGameObject
{
    public Sprite GetSprite();
    public void SetSprite(Sprite sprite);
    public void Update(GameTime gameTime);
    public void Draw(GameTime gameTime);
    public bool IsAlive();
    public void SetAlive(bool alive);
}
public interface IGameObject<T> where T : Sprite
{
    public T GetSprite();
    public void SetSprite(T sprite);
    public void Update(GameTime gameTime);
    public void Draw(GameTime gameTime);
    public bool IsAlive();
    public void SetAlive(bool alive);
}

public class GameObject<T> : IGameObject where T : Sprite
{
    private T sprite;
    private bool alive { get; set; }

    public GameObject(T sprite)
    {
        this.sprite = sprite;
        this.alive = true;
    }

    public virtual void Update(GameTime gameTime)
    {
        this.GetSprite().Update(gameTime);
    }

    public virtual void Draw(GameTime gameTime)
    {
        this.GetSprite().Draw(gameTime);
    }

    public T GetSprite()
    {
        return this.sprite;
    }

    public void SetSprite(Sprite sprite)
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

    Sprite IGameObject.GetSprite()
    {
        throw new System.NotImplementedException();
    }
}