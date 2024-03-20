using Microsoft.Xna.Framework;
using Library.Esliph.Common;
using Pong.Scenes.Rotation.Entities;

namespace Test.Scenes;

public class RotationScene : Scene
{
    public RotationScene() : base("Rotation", Color.Black) { }

    public override void Initialize()
    {
        this.AddGameObjects(
            new RectangleRotation(new(300, 200))
        );

        base.Initialize();
    }
}