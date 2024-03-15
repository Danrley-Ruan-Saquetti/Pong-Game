using System;
using System.Linq;
using System.Collections.Generic;
using Library.Esliph.Common;
using Library.Esliph.Sprites;

namespace Library.Esliph.Controller;

public class GameController
{
    private readonly static GameController instance = new();
    private readonly List<IScenario> scenarios;
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

    private GameController()
    {
        this.scenarios = new();
        this.currentScenarioIndex = 0;
    }

    public void CreateScenario<TScenario>() where TScenario : Scenario, new()
    {
        Scenario scenario = new TScenario();

        this.AddScenario(scenario);
    }

    private void AddScenario(IScenario scenario)
    {
        this.scenarios.Add(scenario);
    }

    public void ToggleScenario(string nameScenario)
    {
        var scenarioIndex = this.scenarios.FindIndex(scenario => scenario.GetName() == nameScenario);

        if (scenarioIndex < 0)
        {
            throw new Exception("Scenario \"" + nameScenario + "\" not found");
        }

        this.ToggleScenario(scenarioIndex);
    }

    public void ToggleScenario(int scenarioIndex)
    {
        this.currentScenarioIndex = scenarioIndex;
        this.GetScenario(scenarioIndex).Initialize();
    }

    public List<IGameObject<ISprite>> GetGameObjectsOfTheScenario(int scenarioIndex)
    {
        return this.GetScenario(scenarioIndex).GetGameObjects();
    }

    public List<IGameObject<ISprite>> GetGameObjectsOfTheCurrentScenario()
    {
        return this.GetCurrentScenario().GetGameObjects();
    }

    public List<IGameObject<ISprite>> GetGameObjectsAliveOfTheScenario(int scenarioIndex)
    {
        return this.GetScenario(scenarioIndex).GetGameObjectsIsAlive();
    }

    public List<IGameObject<ISprite>> GetGameObjectsAliveOfTheCurrentScenario()
    {
        return this.GetCurrentScenario().GetGameObjectsIsAlive();
    }

    public List<IGameObject<ISprite>> GetGameObjectsToUpdateOfTheCurrentScenario()
    {
        return this.GetCurrentScenario().GetGameObjectsToUpdate();
    }

    public List<IGameObject<ISprite>> GetGameObjectsToDrawOfTheCurrentScenario()
    {
        return this.GetCurrentScenario().GetGameObjectsToDraw();
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