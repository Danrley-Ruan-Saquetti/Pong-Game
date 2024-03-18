using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Library.Esliph.Utils;
using Library.Esliph.Global;
using Library.Esliph.Controller;
using System.Linq;

namespace Library.Esliph.Core;

public class AppGame : Game
{
    protected readonly GraphicsDeviceManager graphics;
    protected readonly GameController gameController;

    public AppGame(Dimension windowDimension = null, int FSP = 60)
    {
        if (windowDimension == null)
        {
            windowDimension = GlobalCore.WINDOW_DIMENSION;
        }
        this.graphics = new GraphicsDeviceManager(this)
        {
            PreferredBackBufferWidth = (int)windowDimension.Width,
            PreferredBackBufferHeight = (int)windowDimension.Height
        };
        this.gameController = GameController.GetInstance();
    }

    public void Setup()
    {
        this.Initialize();
    }

    protected override void Initialize()
    {
        if (this.gameController.GetScenarios().Count == 0)
            this.gameController.CreateScenario<BaseScenario>();

        this.IsMouseVisible = true;

        graphics.ApplyChanges();
        base.Initialize();
    }

    protected override void LoadContent()
    {
        SpriteBatchExtensions.LoadContent(this.GraphicsDevice);

        base.LoadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        this.gameController.SetGameTime(gameTime);

        var gameObjects = this.gameController.GetGlobalGameObjectsIsAlive().Concat(this.gameController.GetGameObjectsToUpdateOfTheCurrentScenario()).ToList();

        foreach (var gameObject in gameObjects)
        {
            gameObject.Update();
        }
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(this.gameController.GetCurrentScenario().GetBackgroundColor());

        SpriteBatchExtensions.GetSpriteBatch().Begin();

        var gameObjects = this.gameController.GetGameObjectsToDrawOfTheCurrentScenario();

        foreach (var gameObject in gameObjects)
        {
            gameObject.Draw();
        }

        SpriteBatchExtensions.GetSpriteBatch().End();

        base.Draw(gameTime);
    }
}
