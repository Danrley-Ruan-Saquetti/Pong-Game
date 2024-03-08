using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Library.Esliph;
using Pong.Global;
using Pong.Entities;

namespace Pong;

public class App : GameCore
{
    public App() : base(GameGlobals.WINDOW_DIMENSION)
    {
        this.Content.RootDirectory = "Content";
    }

    protected override void Initialize()
    {
        int gap = 15;

        this.GetCurrentScenario().state.AddGameObject(
            new PlayerUser(gap),
            new PlayerIA(GameGlobals.WINDOW_DIMENSION.Width - GameGlobals.PLAYER_DIMENSION.Width - gap)
        );

        base.Initialize();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        base.Draw(gameTime);
    }
}