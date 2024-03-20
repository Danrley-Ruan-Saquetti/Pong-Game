using Microsoft.Xna.Framework;
using Library.Esliph.Common;
using Pong.Scenes.Sound.Entities;

namespace Test.Scenes;

public class SoundScene : Scene
{
    public SoundScene() : base("Sound", Color.Black) { }

    public override void Initialize()
    {
        this.AddGameObjects(
            new Sound()
        );

        base.Initialize();
    }
}