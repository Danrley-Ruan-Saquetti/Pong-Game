using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Library.Esliph;
using Pong.Global;
using Pong.Scenarios;

namespace Pong;

public class App : GameCore
{
    public App() : base(GameGlobals.WINDOW_DIMENSION)
    {
        this.Content.RootDirectory = "Content";
    }

    protected override void Initialize()
    {
        this.CreateScenario<MainScenario>();
        this.CreateScenario<ColliderTestScenario>();

        this.ToggleScenario("Game");

        base.Initialize();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            Exit();
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        base.Draw(gameTime);
    }
}