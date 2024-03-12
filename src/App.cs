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
        MainScenario mainScenario = new();
        ColliderTestScenario colliderTestScenario = new();

        mainScenario.Initialize();
        colliderTestScenario.Initialize();

        this.AddScenario(mainScenario);
        this.AddScenario(colliderTestScenario);

        this.ToggleScenario("ColliderTest");

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