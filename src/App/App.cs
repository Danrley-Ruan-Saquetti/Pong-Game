using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Library.Esliph.Core;
using Pong.Global;
using Pong.Scenarios;
using Test.Scenarios;
using Pong.Scripts;

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
            new ToggleScenarioScript()
        );
        this.gameController.CreateScenario<MainScenario>();
        this.gameController.CreateScenario<RotationScenario>();

        // this.gameController.ToggleScenario("Main");
        this.gameController.ToggleScenario("Rotation");

        // this.graphics.IsFullScreen = true;
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