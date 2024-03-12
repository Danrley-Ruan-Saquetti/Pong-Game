using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Library.Esliph.Common;

public interface IScenario
{
    public void Initialize();
    public void AddGameObjects(params IGameObject[] gameObjects);
    public void RemoveGameObject(int index);
    public List<IGameObject> GetGameObjects();
    public List<IGameObject> GetGameObjectsIsAlive();
    public List<IGameObject> GetGameObjectsIsVisible();
    public List<IGameObject> GetGameObjectsIsComponentGame();
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
        this.gameObjects.AddRange(gameObjects);

        foreach (var gameObject in gameObjects)
        {
            gameObject.Start();
        }
    }

    public void RemoveGameObject(int index)
    {
        this.gameObjects.RemoveAt(index);
    }

    public List<IGameObject> GetGameObjects()
    {
        return this.gameObjects;
    }

    public List<IGameObject> GetGameObjectsIsAlive()
    {
        return this.gameObjects.Where(gameObject => gameObject.IsAlive()).ToList();
    }

    public List<IGameObject> GetGameObjectsIsVisible()
    {
        return this.gameObjects.Where(gameObject => gameObject.IsVisible()).ToList();
    }

    public List<IGameObject> GetGameObjectsIsComponentGame()
    {
        return this.gameObjects.Where(gameObject => gameObject.IsComponentGame()).ToList();
    }

    public List<IGameObject> GetGameObjectsToUpdate()
    {
        return this.gameObjects.Where(gameObject => gameObject.IsAlive()).ToList();
    }

    public List<IGameObject> GetGameObjectsToDraw()
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