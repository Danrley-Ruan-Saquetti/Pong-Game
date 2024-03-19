using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Library.Esliph.Common;
using Library.Esliph.Shapes;

namespace Library.Esliph.Controller;

public class GameController
{
    private readonly static GameController instance = new();
    private readonly List<IScene> scenes;
    private readonly GameObjectsController globalGameObjectsController;
    private GameTime gameTime = new();
    private int currentSceneIndex { get; set; }
    private IScene currentScene
    {
        get
        {
            return this.scenes.ElementAt(this.currentSceneIndex);
        }
    }

    public static GameController GetInstance()
    {
        return GameController.instance;
    }

    public GameController()
    {
        this.scenes = new();
        this.globalGameObjectsController = new();
        this.currentSceneIndex = 0;
    }

    public void CreateScene<TScene>() where TScene : Scene, new()
    {
        IScene scene = new TScene();

        this.AddScene(scene);
    }

    private void AddScene(IScene scene)
    {
        this.scenes.Add(scene);
        scene.Initialize();
    }

    public void ToggleScene(string nameScene)
    {
        var sceneIndex = this.scenes.FindIndex(scene => scene.GetName() == nameScene);

        if (sceneIndex < 0)
        {
            throw new Exception($"Scene \"{nameScene}\" not found");
        }

        this.ToggleScene(sceneIndex);
    }

    public void ToggleScene(int sceneIndex)
    {
        this.currentSceneIndex = sceneIndex;
    }

    public List<IGameObject> GetGameObjectsOfTheScene(int sceneIndex)
    {
        return this.GetScene(sceneIndex).GetGameObjects();
    }

    public List<IGameObject> GetGameObjectsOfTheCurrentScene()
    {
        return this.GetCurrentScene().GetGameObjects();
    }

    public List<IGameObject> GetGameObjectsAliveOfTheScene(int sceneIndex)
    {
        return this.GetScene(sceneIndex).GetGameObjectsIsAlive();
    }

    public List<IGameObject> GetGameObjectsAliveInAreaOfTheCurrentScene(Vector2 position, float radius)
    {
        return this.GetGameObjectsAliveOfTheCurrentScene().Where(gameObject => gameObject.GetShape2D<Shape2D>().IsInsideArea(position, radius)).ToList();
    }

    public List<IGameObject> GetGameObjectsAliveOfTheCurrentScene(params Guid[] ignoreIds)
    {
        return this.GetCurrentScene().GetGameObjectsIsAlive(ignoreIds);
    }

    public List<IGameObject> GetGameObjectsToUpdateOfTheCurrentScene()
    {
        return this.GetCurrentScene().GetGameObjectsToUpdate();
    }

    public List<IGameObject> GetGameObjectsToDrawOfTheCurrentScene()
    {
        return this.GetCurrentScene().GetGameObjectsToDraw();
    }

    public void AddGlobalGameObjects(params IGameObject[] gameObjects)
    {
        this.globalGameObjectsController.AddGameObjects(gameObjects);
    }

    public List<IGameObject> GetGlobalGameObjectsIsAlive(params Guid[] ignoreIds)
    {
        return this.globalGameObjectsController.GetGameObjectsIsAlive(ignoreIds);
    }

    public void SetGameTime(GameTime gameTime)
    {
        this.gameTime = gameTime;
    }

    public GameTime GetGameTime()
    {
        return this.gameTime;
    }

    public float GetCountFPS()
    {
        return 1f / (float)this.gameTime.ElapsedGameTime.TotalSeconds;
    }

    public List<IScene> GetScenes()
    {
        return this.scenes;
    }

    public IScene GetCurrentScene()
    {
        return this.currentScene;
    }

    public IScene GetScene(string name)
    {
        return this.scenes.Find(scene => scene.GetName() == name);
    }

    public IScene GetScene(int sceneIndex)
    {
        return this.scenes.ElementAt(sceneIndex);
    }
}