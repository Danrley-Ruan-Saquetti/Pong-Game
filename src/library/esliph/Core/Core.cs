using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Library.Esliph.Core;

public class Core : Game
{
    private GraphicsDeviceManager _graphics;

    public Core()
    {
        _graphics = new GraphicsDeviceManager(this);
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        SpriteBatchExtensions.LoadContent(this.GraphicsDevice);

        base.LoadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        SpriteBatchExtensions.GetSpriteBatch().Begin();

        // SpriteBatchExtensions.DrawRectangleFilled(new(10, 10, 50, 50), Color.Black);
        // SpriteBatchExtensions.DrawRectangleOutline(new(80, 10, 50, 50), Color.Black);
        // SpriteBatchExtensions.DrawCircleOutline(new(35, 95), 25, 36, Color.Black);
        // SpriteBatchExtensions.DrawLine(new(10, 140), new(15, 160), Color.Black);

        SpriteBatchExtensions.GetSpriteBatch().End();

        base.Draw(gameTime);
    }
}
