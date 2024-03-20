using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Library.Esliph.Core;
using Pong.Scripts;
using Pong.Global;
using Pong.Scenes;
using Test.Scenes;

namespace Pong;

public class App : AppGame
{
    public App() : base(GlobalGame.WINDOW_DIMENSION, 20)
    {
        this.Content.RootDirectory = "Content";
    }

    protected override void Initialize()
    {
        this.gameController.AddGlobalGameObjects(
        // new MouseTest(),
            new ToggleSceneScript()
        );
        this.gameController.CreateScene<MainScene>();
        this.gameController.CreateScene<RotationScene>();
        // this.gameController.CreateScene<SoundScene>();
        this.gameController.CreateScene<PothioScene>(true);

        this.Window.AllowUserResizing = true;
        this.graphics.IsFullScreen = false;
        this.IsFixedTimeStep = true;
        this.graphics.SynchronizeWithVerticalRetrace = false;

        base.Initialize();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            this.Exit();
        }
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        base.Draw(gameTime);
    }
}