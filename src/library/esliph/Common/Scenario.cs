using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Library.Esliph.Common;

public interface IScenario
{
    public void Initialize() { }
    public void AddGameObjects(params IGameObject[] gameObjects);
    public void RemoveGameObjectById(Guid id);
    public void RemoveGameObject(int index);
    public List<IGameObject> GetGameObjects();
    public List<T> GetGameObjects<T>() where T : IGameObject;
    public T GetGameObject<T>() where T : IGameObject;
    public IGameObject GetGameObject(Guid id);
    public T GetGameObject<T>(Guid id) where T : IGameObject;
    public List<IGameObject> GetGameObjectsIsAlive(params Guid[] ignoreIds);
    public List<IGameObject> GetGameObjectsIsVisible();
    public List<IGameObject> GetGameObjectsToUpdate();
    public List<IGameObject> GetGameObjectsToDraw();
    public Color GetBackgroundColor();
    public void SetBackgroundColor(Color color);
    public string GetName();
    public void SetName(string name);
}

public class Scenario : IScenario
{
    private string name { get; set; }
    private List<IGameObject> gameObjects;
    private Color backgroundColor;

    public Scenario(string name, Color backgroundColor = new())
    {
        this.name = name;
        this.backgroundColor = backgroundColor;
        this.gameObjects = new();
    }

    public virtual void Initialize() { }

    public void AddGameObjects(params IGameObject[] gameObjects)
    {
        foreach (var gameObject in gameObjects)
        {
            this.gameObjects.Add(gameObject);

            gameObject.Start();
        }
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

    public List<IGameObject> GetGameObjects()
    {
        return this.gameObjects;
    }

    public List<T> GetGameObjects<T>() where T : IGameObject
    {
        return this.gameObjects.Where(gameObject => gameObject is T).ToList() as List<T>;
    }

    public T GetGameObject<T>() where T : IGameObject
    {
        var gameObject = (T)this.gameObjects.Find(gameObject => gameObject is T);

        if (gameObject == null)
        {
            throw new Exception("Game Object \"" + gameObject.GetType().Name + "\" not found");
        }

        return gameObject;
    }

    public IGameObject GetGameObject(Guid id)
    {
        return this.GetGameObject<IGameObject>(id);
    }

    public T GetGameObject<T>(Guid id) where T : IGameObject
    {
        return (T)this.gameObjects.Find(gameObject => gameObject.GetId() == id);
    }

    public List<IGameObject> GetGameObjectsIsAlive(params Guid[] ignoreIds)
    {
        return this.gameObjects.Where(gameObject => gameObject.IsAlive() && !ignoreIds.Contains(gameObject.GetId())).ToList();
    }

    public List<IGameObject> GetGameObjectsIsVisible()
    {
        return this.gameObjects.Where(gameObject => gameObject.IsVisible()).ToList();
    }

    public List<IGameObject> GetGameObjectsToUpdate()
    {
        return this.gameObjects.Where(gameObject => gameObject.IsAlive()).ToList();
    }

    public List<IGameObject> GetGameObjectsToDraw()
    {
        return this.gameObjects.Where(gameObject => gameObject.IsVisible() && gameObject.IsAlive()).ToList();
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