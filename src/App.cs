using Microsoft.Xna.Framework;
using Library.Esliph.Core;
using Library.Esliph.Global;

namespace Pong;

public class App : Core
{
    public App() : base(new(), Globals.WINDOW_DIMENSION)
    {
        this.Content.RootDirectory = "Content";
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        base.Draw(gameTime);
    }
}