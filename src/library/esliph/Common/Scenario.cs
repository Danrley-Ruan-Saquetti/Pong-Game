using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Library.Esliph.Sprites;

namespace Library.Esliph.Common;

public interface IScenario
{
    public void Initialize();
    public void AddGameObject<GISprite>(IGameObject<GISprite> gameObject) where GISprite : ISprite;
    public void RemoveGameObjectById(Guid id);
    public void RemoveGameObject(int index);
    public List<IGameObject<ISprite>> GetGameObjects();
    public List<T> GetGameObjects<T>() where T : IGameObject<ISprite>;
    public T GetGameObject<T>() where T : IGameObject<ISprite>;
    public List<IGameObject<ISprite>> GetGameObjectsIsAlive();
    public List<IGameObject<ISprite>> GetGameObjectsIsVisible();
    public List<IGameObject<ISprite>> GetGameObjectsIsComponentGame();
    public List<IGameObject<T>> GetGameObjectsIsComponentGame<T>() where T : ISprite;
    public List<IGameObject<ISprite>> GetGameObjectsToUpdate();
    public List<IGameObject<ISprite>> GetGameObjectsToDraw();
    public Color GetBackgroundColor();
    public void SetBackgroundColor(Color color);
    public string GetName();
    public void SetName(string name);
}

public class Scenario : IScenario
{
    private string name { get; set; }
    private List<IGameObject<ISprite>> gameObjects;
    private Color backgroundColor;

    public Scenario(string name, Color backgroundColor = new())
    {
        this.name = name;
        this.backgroundColor = backgroundColor;
        this.gameObjects = new();
    }

    public virtual void Initialize() { }

    public void AddGameObject<GISprite>(IGameObject<GISprite> gameObject) where GISprite : ISprite
    {
        this.gameObjects.Add((GameObject<ISprite>)gameObject);

        gameObject.Start();
    }

    public void RemoveGameObjectById(Guid id)
    {
        int index = this.GetGameObjects().FindIndex(gameObject => gameObject.GetId() == id);

        if (index < 0)
        {
            throw new Exception("Game Object ID \"" + id.ToString() + "\" not found");
        }

        this.RemoveGameObject(index);
    }

    public void RemoveGameObject(int index)
    {
        this.gameObjects.RemoveAt(index);
    }

    public List<IGameObject<ISprite>> GetGameObjects()
    {
        return this.gameObjects;
    }

    public List<T> GetGameObjects<T>() where T : IGameObject<ISprite>
    {
        return this.gameObjects.Where(gameObject => gameObject is T).ToList() as List<T>;
    }

    public T GetGameObject<T>() where T : IGameObject<ISprite>
    {
        var gameObject = (T)this.gameObjects.Find(gameObject => gameObject is T);

        if (gameObject == null)
        {
            throw new Exception("Game Object \"" + gameObject.GetType().Name + "\" not found");
        }

        return gameObject;
    }

    public List<IGameObject<ISprite>> GetGameObjectsIsAlive()
    {
        return this.gameObjects.Where(gameObject => gameObject.IsAlive()).ToList();
    }

    public List<IGameObject<ISprite>> GetGameObjectsIsVisible()
    {
        return this.gameObjects.Where(gameObject => gameObject.IsVisible()).ToList();
    }

    public List<IGameObject<ISprite>> GetGameObjectsIsComponentGame()
    {
        return this.gameObjects.Where(gameObject => gameObject.IsComponentGame()).ToList();
    }

    public List<IGameObject<T>> GetGameObjectsIsComponentGame<T>() where T : ISprite
    {
        return this.gameObjects.Where(gameObject => gameObject.IsComponentGame() && gameObject.GetSprite() is T).ToList() as List<IGameObject<T>>;
    }

    public List<IGameObject<ISprite>> GetGameObjectsToUpdate()
    {
        return this.gameObjects.Where(gameObject => gameObject.IsAlive()).ToList();
    }

    public List<IGameObject<ISprite>> GetGameObjectsToDraw()
    {
        return this.gameObjects.Where(gameObject => gameObject.IsVisible() && gameObject.IsAlive() && gameObject.IsComponentGame()).ToList();
    }

    public Color GetBackgroundColor()
    {
        return this.backgroundColor;
    }

    public void SetBackgroundColor(Color color)
    {
        this.backgroundColor = color;
    }

    public string GetName()
    {
        return this.name;
    }

    public void SetName(string name)
    {
        this.name = name;
    }
}