using Microsoft.Xna.Framework;
using Library.Esliph.Sprites;
using Library.Esliph.Components;
using System.Collections.Generic;
using System.Linq;

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
    public bool IsVisible();
    public void SetVisible(bool visible);
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
    private List<string> tags;
    private T sprite;
    private bool alive { get; set; }
    private bool visible { get; set; }

    public GameObject(T sprite = default, bool visible = true)
    {
        this.sprite = sprite;
        this.visible = visible;
        this.alive = true;
        this.tags = new();
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

    public void AddTags(params string[] tags)
    {
        this.tags.AddRange(tags);
    }

    public bool CompareTo(string tagName)
    {
        return this.tags.Any(tag => tag == tagName);
    }

    public List<string> GetTags()
    {
        return this.tags;
    }

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

    public bool IsVisible()
    {
        return visible;
    }

    public void SetVisible(bool visible)
    {
        this.visible = visible;
    }

    ISprite IGameObject.GetSprite()
    {
        return this.sprite;
    }
}