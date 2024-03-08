using System.Collections.Generic;
using Library.Esliph.Common;
using Library.Esliph.Components;
using Library.Esliph.Global;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Library.Esliph.Core;

public class Core : Game
{
    private GraphicsDeviceManager _graphics;
    private List<GameObject> gameObjects;
    public Color backgroundColor;

    public Core(Color backgroundColor = new(), Dimension windowDimension = null)
    {
        windowDimension = windowDimension ?? Globals.WINDOW_DIMENSION;
        this._graphics = new GraphicsDeviceManager(this)
        {
            PreferredBackBufferWidth = (int)windowDimension.Width,
            PreferredBackBufferHeight = (int)windowDimension.Height
        };
        this.IsMouseVisible = true;
        this.gameObjects = new();
        this.backgroundColor = backgroundColor;
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

        foreach (var gameObject in this.gameObjects)
        {
            gameObject.Update(gameTime);
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(this.backgroundColor);

        SpriteBatchExtensions.GetSpriteBatch().Begin();

        foreach (var gameObject in this.gameObjects)
        {
            gameObject.Draw(gameTime);
        }

        SpriteBatchExtensions.GetSpriteBatch().End();

        base.Draw(gameTime);
    }

    public void AddGameObject(GameObject gameObject)
    {
        this.gameObjects.Add(gameObject);
    }

    public void RemoveGameObject(int index)
    {
        this.gameObjects.RemoveAt(index);
    }
}
