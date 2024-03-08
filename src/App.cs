using Microsoft.Xna.Framework;
using Library.Esliph.Core;
using Pong.Global;
using Pong.Entities;
using Microsoft.Xna.Framework.Input;

namespace Pong;

public class App : Core
{
    public App() : base(new(), GameGlobals.WINDOW_DIMENSION)
    {
        this.Content.RootDirectory = "Content";
    }

    protected override void Initialize()
    {
        this.AddGameObject(
            new Player(15),
            new Player((int)(GameGlobals.WINDOW_DIMENSION.Width - 15 - GameGlobals.PLAYER_DIMENSION.Width))
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