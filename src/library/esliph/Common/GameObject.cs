using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Library.Esliph.Sprites;
using Library.Esliph.Controller;
using Library.Esliph.Components;

namespace Library.Esliph.Common;

public interface IGameObject<GISprite> where GISprite : ISprite
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
    public bool IsComponentGame();
    public GISprite GetSprite();
    public void SetSprite(GISprite sprite);
    public void AddComponents(params IComponent[] components);
    public List<IComponent> GetComponents();
    public List<GIComponent> GetComponents<GIComponent>() where GIComponent : IComponent;
    public GIComponent GetComponent<GIComponent>() where GIComponent : IComponent;
}

public class GameObject<GISprite> : IGameObject<GISprite> where GISprite : ISprite
{
    protected GameController gameController = GameController.GetInstance();
    private readonly Guid id;
    private List<string> tags;
    private GISprite sprite;
    private bool alive, visible;
    private readonly bool componentGame;
    private List<IComponent> components;

    public GameObject(GISprite sprite = default, bool isComponentGame = true)
    {
        this.sprite = sprite;
        this.visible = true;
        this.alive = true;
        this.componentGame = isComponentGame;
        this.tags = new();
        this.id = Guid.NewGuid();
        this.components = new();
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

    public GISprite GetSprite()
    {
        return this.sprite;
    }

    public void SetSprite(GISprite sprite)
    {
        this.sprite = sprite;
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

    public List<IComponent> GetComponents()
    {
        return this.components;
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
