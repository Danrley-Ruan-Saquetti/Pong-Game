using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Library.Esliph.Common;
using Library.Esliph.Components;
using Library.Esliph.Global;
using Library.Esliph.Core;
using System.Linq;

namespace Library.Esliph;

public class GameCore : Game
{
    private GraphicsDeviceManager _graphics;
    private readonly List<Scenario> scenarios;
    private int currentScenarioIndex { get; set; }

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
        this.NewScenario();
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
        Scenario scenario = this.GetCurrentScenario();

        foreach (var gameObject in scenario.GetGameObjects())
        {
            if (!gameObject.IsAlive())
            {
                continue;
            }
            gameObject.Update(gameTime);
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        Scenario scenario = this.GetCurrentScenario();

        GraphicsDevice.Clear(scenario.backgroundColor);

        SpriteBatchExtensions.GetSpriteBatch().Begin();

        foreach (var gameObject in scenario.GetGameObjects())
        {
            if (!gameObject.IsAlive())
            {
                continue;
            }
            gameObject.Draw(gameTime);
        }

        SpriteBatchExtensions.GetSpriteBatch().End();

        base.Draw(gameTime);
    }

    public Scenario NewScenario()
    {
        Scenario scenario = new();

        this.scenarios.Add(scenario);

        return scenario;
    }

    public List<Scenario> GetScenarios()
    {
        return this.scenarios;
    }

    public Scenario GetCurrentScenario()
    {
        return this.scenarios.ElementAt(this.currentScenarioIndex);
    }

    public Scenario GetScenario(int scenarioIndex)
    {
        return this.scenarios.ElementAt(scenarioIndex);
    }
}
