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
    private readonly List<IScenario> scenarios;
    private readonly GameObjectsController globalGameObjectsController;
    private GameTime gameTime = new();
    private int currentScenarioIndex { get; set; }
    private IScenario currentScenario
    {
        get
        {
            return this.scenarios.ElementAt(this.currentScenarioIndex);
        }
    }

    public static GameController GetInstance()
    {
        return GameController.instance;
    }

    public GameController()
    {
        this.scenarios = new();
        this.globalGameObjectsController = new();
        this.currentScenarioIndex = 0;
    }

    public void CreateScenario<TScenario>() where TScenario : Scenario, new()
    {
        IScenario scenario = new TScenario();

        this.AddScenario(scenario);
    }

    private void AddScenario(IScenario scenario)
    {
        this.scenarios.Add(scenario);
        scenario.Initialize();
    }

    public void ToggleScenario(string nameScenario)
    {
        var scenarioIndex = this.scenarios.FindIndex(scenario => scenario.GetName() == nameScenario);

        if (scenarioIndex < 0)
        {
            throw new Exception($"Scenario \"{nameScenario}\" not found");
        }

        this.ToggleScenario(scenarioIndex);
    }

    public void ToggleScenario(int scenarioIndex)
    {
        this.currentScenarioIndex = scenarioIndex;
    }

    public List<IGameObject> GetGameObjectsOfTheScenario(int scenarioIndex)
    {
        return this.GetScenario(scenarioIndex).GetGameObjects();
    }

    public List<IGameObject> GetGameObjectsOfTheCurrentScenario()
    {
        return this.GetCurrentScenario().GetGameObjects();
    }

    public List<IGameObject> GetGameObjectsAliveOfTheScenario(int scenarioIndex)
    {
        return this.GetScenario(scenarioIndex).GetGameObjectsIsAlive();
    }

    public List<IGameObject> GetGameObjectsAliveInAreaOfTheCurrentScenario(Vector2 position, float radius)
    {
        return this.GetGameObjectsAliveOfTheCurrentScenario().Where(gameObject => gameObject.GetShape2D<Shape2D>().IsInsideArea(position, radius)).ToList();
    }

    public List<IGameObject> GetGameObjectsAliveOfTheCurrentScenario(params Guid[] ignoreIds)
    {
        return this.GetCurrentScenario().GetGameObjectsIsAlive(ignoreIds);
    }

    public List<IGameObject> GetGameObjectsToUpdateOfTheCurrentScenario()
    {
        return this.GetCurrentScenario().GetGameObjectsToUpdate();
    }

    public List<IGameObject> GetGameObjectsToDrawOfTheCurrentScenario()
    {
        return this.GetCurrentScenario().GetGameObjectsToDraw();
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

    public List<IScenario> GetScenarios()
    {
        return this.scenarios;
    }

    public IScenario GetCurrentScenario()
    {
        return this.currentScenario;
    }

    public IScenario GetScenario(string name)
    {
        return this.scenarios.Find(scenario => scenario.GetName() == name);
    }

    public IScenario GetScenario(int scenarioIndex)
    {
        return this.scenarios.ElementAt(scenarioIndex);
    }
}