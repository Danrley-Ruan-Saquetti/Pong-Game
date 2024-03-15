using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Library.Esliph.Controller;
using Library.Esliph.Components;
using Library.Esliph.Sprites;

namespace Library.Esliph.Common;

public interface IGameObject
{
    public void Start();
    public void Update(GameTime gameTime);
    public void Draw(GameTime gameTime);
    public Guid GetId();
    public void AddTags(params string[] tags);
    public bool CompareTo(string tagName);
    public List<string> GetTags();
    public bool IsAlive();
    public void SetAlive(bool alive);
    public bool IsVisible();
    public void SetVisible(bool visible);
    public void AddComponents(params IComponent[] components);
    public GISprite GetSprite<GISprite>() where GISprite : ISprite;
    public List<IComponent> GetComponents();
    public List<GIComponent> GetComponents<GIComponent>() where GIComponent : IComponent;
    public GIComponent GetComponent<GIComponent>() where GIComponent : IComponent;
}

public class GameObject : IGameObject
{
    protected GameController gameController = GameController.GetInstance();
    private readonly Guid id;
    private List<string> tags;
    private bool alive, visible;
    private List<IComponent> components;

    public GameObject()
    {
        this.visible = true;
        this.alive = true;
        this.tags = new();
        this.id = Guid.NewGuid();
        this.components = new();
    }

    public virtual void Start() { }

    public virtual void Update(GameTime gameTime)
    {
        var componentsActive = this.GetComponentsActive();

        foreach (var component in componentsActive)
        {
            component.Update(gameTime, this);
        }
    }

    public virtual void Draw(GameTime gameTime)
    {
        ISprite sprite = this.GetSprite<ISprite>();

        if (sprite == null)
        {
            return;
        }

        sprite.Draw(gameTime);
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

    public Guid GetId()
    {
        return this.id;
    }

    public void AddComponents(params IComponent[] components)
    {
        this.components.AddRange(components);

        foreach (var component in components)
        {
            component.Start();
        }
    }

    public GISprite GetSprite<GISprite>() where GISprite : ISprite
    {
        return this.GetComponent<GISprite>();
    }

    public List<IComponent> GetComponents()
    {
        return this.components;
    }

    public List<IComponent> GetComponentsActive()
    {
        return this.components.Where(component => component.IsActive()).ToList();
    }

    public List<GIComponent> GetComponents<GIComponent>() where GIComponent : IComponent
    {
        return this.components.Where(component => component is GIComponent).ToList() as List<GIComponent>;
    }

    public GIComponent GetComponent<GIComponent>() where GIComponent : IComponent
    {
        return (GIComponent)this.components.Find(component => component is GIComponent);
    }
}
