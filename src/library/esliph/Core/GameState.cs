using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Library.Esliph.Common;

namespace Library.Esliph.Core;

public class StateGame
{
    private List<IGameObject> gameObjects;
    public Color backgroundColor;

    public StateGame(Color backgroundColor = new())
    {
        this.backgroundColor = backgroundColor;
        this.gameObjects = new();
    }

    public void AddGameObject(params IGameObject[] gameObjects)
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