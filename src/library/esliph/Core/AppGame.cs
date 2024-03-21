using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Library.Esliph.Utils;
using Library.Esliph.Global;
using Library.Esliph.Controller;

namespace Library.Esliph.Core;

public class AppGame : Game
{
    protected readonly GraphicsDeviceManager graphics;
    protected readonly GameController gameController;
    protected readonly MouseController mouseController;
    protected readonly KeyboardController keyboardController;

    public AppGame(Dimension windowDimension = null, int FPS = 60)
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
        this.mouseController = MouseController.GetInstance();
        this.keyboardController = KeyboardController.GetInstance();
        this.gameController.SetLimitFPS(FPS);
        GameController.Initialize(this.Content);
    }

    protected override void Initialize()
    {
        if (this.gameController.GetScenes().Count == 0)
            this.gameController.CreateScene<BaseScene>();

        // this.TargetElapsedTime = TimeSpan.FromSeconds(1d / this.gameController.GetLimitFPS());
        // this.IsFixedTimeStep = true;
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
        this.keyboardController.Update();
        this.mouseController.Update();

        var gameObjects = this.gameController.GetGlobalGameObjectsIsAlive().Concat(this.gameController.GetGameObjectsToUpdateOfTheCurrentScene()).ToList();

        foreach (var gameObject in gameObjects)
        {
            gameObject.Update();
        }
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(this.gameController.GetCurrentScene().GetBackgroundColor());

        SpriteBatchExtensions.GetSpriteBatch().Begin();

        var gameObjects = this.gameController.GetGameObjectsToDrawOfTheCurrentScene();

        foreach (var gameObject in gameObjects)
        {
            gameObject.Draw();
        }

        SpriteBatchExtensions.GetSpriteBatch().End();

        base.Draw(gameTime);
    }
}
