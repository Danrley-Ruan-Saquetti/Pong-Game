using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace Library.Esliph.Common;

public interface IScenario
{
    public void Initialize();
    public void AddGameObjects(params IGameObject[] gameObjects);
    public void RemoveGameObject(int index);
    public List<IGameObject> GetGameObjects();
    public List<IGameObject> GetGameObjectsAlive();
    public List<IGameObject> GetGameObjectsVisible();
    public Color GetBackgroundColor();
    public void SetBackgroundColor(Color color);
}

public class Scenario : IScenario
{
    private List<IGameObject> gameObjects;
    private Color backgroundColor;

    public Scenario(Color backgroundColor = new())
    {
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

    public List<IGameObject> GetGameObjectsAlive()
    {
        return this.gameObjects.Where(gameObject => gameObject.IsAlive()).ToList();
    }

    public List<IGameObject> GetGameObjectsVisible()
    {
        return this.gameObjects.Where(gameObject => gameObject.IsVisible()).ToList();
    }

    public Color GetBackgroundColor()
    {
        return this.backgroundColor;
    }

    public void SetBackgroundColor(Color color)
    {
        this.backgroundColor = color;
    }
}