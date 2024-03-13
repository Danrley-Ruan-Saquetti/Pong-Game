using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Library.Esliph.Common;
using Library.Esliph.Components;
using Library.Esliph.Global;
using Library.Esliph.Core;
using Library.Esliph.Controllers;

namespace Library.Esliph;

public class GameCore : Game
{
    private GraphicsDeviceManager _graphics;
    private readonly List<IScenario> scenarios;
    private int currentScenarioIndex { get; set; }
    private IScenario currentScenario
    {
        get
        {
            return this.scenarios.ElementAt(this.currentScenarioIndex);
        }
    }

    public GameCore(Dimension windowDimension = null)
    {
        if (windowDimension == null)
        {
            windowDimension = Globals.WINDOW_DIMENSION;
        }
        this._graphics = new GraphicsDeviceManager(this)
        {
            PreferredBackBufferWidth = (int)windowDimension.Width,
            PreferredBackBufferHeight = (int)windowDimension.Height
        };
        this.IsMouseVisible = true;
        this.scenarios = new();
        this.currentScenarioIndex = 0;
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        SpriteBatchExtensions.LoadContent(this.GraphicsDevice);

        base.LoadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        var gameObjects = this.GetGameObjectsToUpdateOfTheCurrentScenario();

        foreach (var gameObject in gameObjects)
        {
            gameObject.Update(gameTime);
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(this.currentScenario.GetBackgroundColor());

        SpriteBatchExtensions.GetSpriteBatch().Begin();

        var gameObjects = this.GetGameObjectsToDrawOfTheCurrentScenario();

        foreach (var gameObject in gameObjects)
        {
            gameObject.Draw(gameTime);
        }

        SpriteBatchExtensions.GetSpriteBatch().End();

        base.Draw(gameTime);
    }

    protected void AddScenario(IScenario scenario)
    {
        this.scenarios.Add(scenario);
    }

    protected void ToggleScenario(string nameScenario)
    {
        var scenarioIndex = this.scenarios.FindIndex(scenario => scenario.GetName() == nameScenario);

        if (scenarioIndex < 0)
        {
            throw new Exception("Scenario \"" + nameScenario + "\" not found");
        }

        this.ToggleScenario(scenarioIndex);
    }

    protected void ToggleScenario(int scenarioIndex)
    {
        this.currentScenarioIndex = scenarioIndex;
    }

    protected List<IGameObject> GetGameObjectsOfTheScenario(int scenarioIndex)
    {
        return this.GetScenario(scenarioIndex).GetGameObjects();
    }

    protected List<IGameObject> GetGameObjectsOfTheCurrentScenario()
    {
        return this.GetCurrentScenario().GetGameObjects();
    }

    protected List<IGameObject> GetGameObjectsAliveOfTheScenario(int scenarioIndex)
    {
        return this.GetScenario(scenarioIndex).GetGameObjectsIsAlive();
    }

    protected List<IGameObject> GetGameObjectsAliveOfTheCurrentScenario()
    {
        return this.GetCurrentScenario().GetGameObjectsIsAlive();
    }

    protected List<IGameObject> GetGameObjectsToUpdateOfTheCurrentScenario()
    {
        return this.GetCurrentScenario().GetGameObjectsToUpdate();
    }

    protected List<IGameObject> GetGameObjectsToDrawOfTheCurrentScenario()
    {
        return this.GetCurrentScenario().GetGameObjectsToDraw();
    }

    protected List<IScenario> GetScenarios()
    {
        return this.scenarios;
    }

    protected IScenario GetCurrentScenario()
    {
        return this.currentScenario;
    }

    protected IScenario GetScenario(string name)
    {
        return this.scenarios.Find(scenario => scenario.GetName() == name);
    }

    protected IScenario GetScenario(int scenarioIndex)
    {
        return this.scenarios.ElementAt(scenarioIndex);
    }
}
