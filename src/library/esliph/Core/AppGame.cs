using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Library.Esliph.Utils;
using Library.Esliph.Global;
using Library.Esliph.Controller;

namespace Library.Esliph.Core;

public class AppGame : Game
{
    private readonly GraphicsDeviceManager _graphics;
    protected readonly GameController gameController;

    public AppGame(Dimension windowDimension = null)
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
        this.gameController = GameController.GetInstance();
    }

    public void Setup()
    {
        this.Initialize();
    }

    protected override void Initialize()
    {
        if (this.gameController.GetScenarios().Count == 0)
        {
            this.gameController.CreateScenario<BaseScenario>();
        }

        base.Initialize();
    }

    protected override void LoadContent()
    {
        SpriteBatchExtensions.LoadContent(this.GraphicsDevice);

        base.LoadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        var gameObjects = this.gameController.GetGameObjectsToUpdateOfTheCurrentScenario();

        foreach (var gameObject in gameObjects)
        {
            gameObject.Update(gameTime);
        }
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(this.gameController.GetCurrentScenario().GetBackgroundColor());

        SpriteBatchExtensions.GetSprite2DBatch().Begin();

        var gameObjects = this.gameController.GetGameObjectsToDrawOfTheCurrentScenario();

        foreach (var gameObject in gameObjects)
        {
            gameObject.Draw(gameTime);
        }

        SpriteBatchExtensions.GetSprite2DBatch().End();

        base.Draw(gameTime);
    }
}
