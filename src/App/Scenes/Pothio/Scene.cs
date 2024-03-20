using Microsoft.Xna.Framework;
using Library.Esliph.Common;
using Pong.Scenes.Pothio.Entities;

namespace Test.Scenes;

public class PothioScene : Scene
{
    public PothioScene() : base("Pothio", Color.Black) { }

    public override void Initialize()
    {
        var player = new Player();

        this.AddGameObjects(player);

        base.Initialize();
    }
}