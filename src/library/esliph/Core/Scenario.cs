using System.Collections.Generic;
using Library.Esliph.Common;
using Microsoft.Xna.Framework;

namespace Library.Esliph.Core;

public class Scenario
{
    private List<IGameObject> gameObjects;
    public Color backgroundColor;

    public Scenario(Color backgroundColor = new())
    {
        this.backgroundColor = backgroundColor;
        this.gameObjects = new();
    }

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
}