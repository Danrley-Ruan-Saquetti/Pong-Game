using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Library.Esliph.Core;
using Pong.Global;
using Pong.Scripts;
using Pong.Scenes;
using Test.Scenes;

namespace Pong;

public class App : AppGame
{
    public App() : base(GlobalGame.WINDOW_DIMENSION)
    {
        this.Content.RootDirectory = "Content";
    }

    protected override void Initialize()
    {
        this.gameController.AddGlobalGameObjects(
        // new MouseTest(),
        // new ToggleSceneScript()
        );
        this.gameController.CreateScene<MainScene>();
        this.gameController.CreateScene<RotationScene>();

        this.gameController.ToggleScene("Main");
        // this.gameController.ToggleScene("Rotation");

        this.Window.AllowUserResizing = true;
        this.graphics.IsFullScreen = false;
        this.TargetElapsedTime = TimeSpan.FromSeconds(1d / 60d);
        this.IsFixedTimeStep = true;
        graphics.SynchronizeWithVerticalRetrace = false;

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