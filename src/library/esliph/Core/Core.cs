using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Library.Esliph.Common;
using Library.Esliph.Components;
using Library.Esliph.Global;

namespace Library.Esliph.Core;

public class Core : Game
{
    private GraphicsDeviceManager _graphics;
    private List<GameObject> gameObjects;
    public Color backgroundColor;

    public Core(Color backgroundColor = new(), Dimension windowDimension = null)
    {
        if (windowDimension == null)
        {
            windowDimension = Globals.WINDOW_DIMENSION;
        }
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
        foreach (var gameObject in this.gameObjects)
        {
            if (!gameObject.IsAlive())
            {
                continue;
            }
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
            if (!gameObject.IsAlive())
            {
                continue;
            }
            gameObject.Draw(gameTime);
        }

        SpriteBatchExtensions.GetSpriteBatch().End();

        base.Draw(gameTime);
    }

    public void AddGameObject(params GameObject[] gameObjects)
    {
        this.gameObjects.AddRange(gameObjects);
    }

    public void RemoveGameObject(int index)
    {
        this.gameObjects.RemoveAt(index);
    }
}
