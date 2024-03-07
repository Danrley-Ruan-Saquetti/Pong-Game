using Library.Esliph.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Library.Esliph.Core;

public class Core : Game
{
    private GraphicsDeviceManager _graphics;
    protected readonly SpriteBatchExtensions spriteBatch = new();
    public TriangleSprite sprite;

    public Core()
    {
        _graphics = new GraphicsDeviceManager(this);
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        this.sprite = new(new(10, 10), new(250, 10), new(130, 250));
        base.Initialize();
    }

    protected override void LoadContent()
    {
        this.spriteBatch.LoadContent(this.GraphicsDevice);

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

        this.spriteBatch.GetSpriteBatch().Begin();

        // this.spriteBatch.DrawRectangleFilled(new(10, 10, 50, 50), Color.Black);
        // this.spriteBatch.DrawRectangleOutline(new(80, 10, 50, 50), Color.Black);
        // this.spriteBatch.DrawCircleOutline(new(35, 95), 25, 36, Color.Black);
        // this.spriteBatch.DrawLine(new(10, 140), new(15, 160), Color.Black);

        this.spriteBatch.DrawTriangle(this.sprite.GetPosition(0), this.sprite.GetPosition(1), this.sprite.GetPosition(2), Color.Black);

        this.spriteBatch.GetSpriteBatch().End();

        base.Draw(gameTime);
    }
}
