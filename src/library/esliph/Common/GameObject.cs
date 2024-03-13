using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Library.Esliph.Sprites;
using Library.Esliph.Components;

namespace Library.Esliph.Common;

public interface IGameObject
{
    public void Start();
    public void Update(GameTime gameTime);
    public void Draw(GameTime gameTime);
    public void AddTags(params string[] tags);
    public bool CompareTo(string tagName);
    public List<string> GetTags();
    public void AddComponents(params IComponent[] components);
    public List<IComponent> GetComponents();
    public ISprite GetSprite();
    public void SetSprite(ISprite sprite);
    public bool IsAlive();
    public void SetAlive(bool alive);
    public bool IsVisible();
    public void SetVisible(bool visible);
    public bool IsComponentGame();
}
public interface IGameObject<T> where T : ISprite
{
    public void Start();
    public void Update(GameTime gameTime);
    public void Draw(GameTime gameTime);
    public void AddTags(params string[] tags);
    public bool CompareTo(string tagName);
    public List<string> GetTags();
    public void AddComponents(params IComponent[] components);
    public List<IComponent> GetComponents();
    public T GetSprite();
    public void SetSprite(ISprite sprite);
    public bool IsAlive();
    public void SetAlive(bool alive);
    public bool IsVisible();
    public void SetVisible(bool visible);
    public bool IsComponentGame();
}

public class GameObject<T> : IGameObject where T : ISprite
{
    private List<IComponent> components;
    private List<string> tags;
    private T sprite;
    private bool alive, visible;
    private readonly bool componentGame;

    public GameObject(T sprite = default, bool componentGame = true)
    {
        this.sprite = sprite;
        this.visible = true;
        this.alive = true;
        this.componentGame = componentGame;
        this.tags = new();
        this.components = new();
    }

    public virtual void Start() { }

    public virtual void Update(GameTime gameTime)
    {
        this.UpdateComponents(gameTime);
        this.GetSprite().Update(gameTime);
    }

    public virtual void Draw(GameTime gameTime)
    {
        this.GetSprite().Draw(gameTime);
    }

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

    public void AddComponents(params IComponent[] components)
    {
        this.components.AddRange(components);

        foreach (var component in components)
        {
            component.Start();
        }
    }

    public void UpdateComponents(GameTime gameTime)
    {
        foreach (var component in this.components)
        {
            component.Update(gameTime, this);
        }
    }

    public List<IComponent> GetComponents()
    {
        return this.components;
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

    public bool IsComponentGame()
    {
        return componentGame;
    }

    ISprite IGameObject.GetSprite()
    {
        return this.sprite;
    }
}