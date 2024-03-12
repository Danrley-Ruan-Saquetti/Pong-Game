using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Library.Esliph.Common;
using Library.Esliph.Components;
using Library.Esliph.Global;
using Library.Esliph.Core;

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
        this.ReadKeyboardState(gameTime);

        var gameObjects = this.GetGameObjectsAliveOfTheCurrentScenario();

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

        var gameObjects = this.GetGameObjectsVisibleOfTheCurrentScenario();

        foreach (var gameObject in gameObjects)
        {
            gameObject.Draw(gameTime);
        }

        SpriteBatchExtensions.GetSpriteBatch().End();

        base.Draw(gameTime);
    }

    private void ReadKeyboardState(GameTime gameTime)
    {
        KeyboardState keyboardState = Keyboard.GetState();

        if (keyboardState.GetPressedKeys().Length > 0)
        {
            Keys lastKeyPressed = keyboardState.GetPressedKeys()[0];

            if (keyboardState.IsKeyDown(lastKeyPressed))
            {
                this.OnKeyDown(gameTime, KeyEvent.KeyDown(lastKeyPressed, keyboardState.CapsLock, keyboardState.IsKeyDown(Keys.LeftShift) || keyboardState.IsKeyDown(Keys.RightShift)));
            }

            if (keyboardState.IsKeyUp(lastKeyPressed))
            {
                this.OnKeyUp(gameTime, KeyEvent.KeyUp(lastKeyPressed, keyboardState.CapsLock, keyboardState.IsKeyUp(Keys.LeftShift) || keyboardState.IsKeyUp(Keys.RightShift)));
            }
        }
    }

    public virtual void OnKeyDown(GameTime gameTime, KeyEvent keyEvent)
    {
        this.EmitKeyDownEventToGameObjects(gameTime, keyEvent);
    }

    public virtual void OnKeyUp(GameTime gameTime, KeyEvent keyEvent)
    {
        this.EmitKeyUpEventToGameObjects(gameTime, keyEvent);
    }

    private void EmitKeyDownEventToGameObjects(GameTime gameTime, KeyEvent keyEvent)
    {
        var gameObjects = this.GetGameObjectsAliveOfTheCurrentScenario();

        foreach (var gameObject in gameObjects)
        {
            gameObject.OnKeyDown(gameTime, keyEvent);
        }
    }

    private void EmitKeyUpEventToGameObjects(GameTime gameTime, KeyEvent keyEvent)
    {
        var gameObjects = this.GetGameObjectsAliveOfTheCurrentScenario();

        foreach (var gameObject in gameObjects)
        {
            gameObject.OnKeyUp(gameTime, keyEvent);
        }
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
        return this.GetScenario(scenarioIndex).GetGameObjectsAlive();
    }

    public List<IGameObject> GetGameObjectsAliveOfTheCurrentScenario()
    {
        return this.GetCurrentScenario().GetGameObjectsAlive();
    }

    public List<IGameObject> GetGameObjectsVisibleOfTheCurrentScenario()
    {
        return this.GetCurrentScenario().GetGameObjectsVisible();
    }

    public IScenario NewScenario()
    {
        IScenario scenario = new Scenario();

        this.AddScenario(scenario);

        return scenario;
    }

    public void AddScenario(IScenario scenario)
    {
        this.scenarios.Add(scenario);
    }

    public List<IScenario> GetScenarios()
    {
        return this.scenarios;
    }

    public IScenario GetCurrentScenario()
    {
        return this.currentScenario;
    }

    public IScenario GetScenario(int scenarioIndex)
    {
        return this.scenarios.ElementAt(scenarioIndex);
    }
}
