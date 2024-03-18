using Microsoft.Xna.Framework;
using Library.Esliph.Common;
using Pong.Scenarios.Rotation.Entities;

namespace Test.Scenarios;

public class RotationScenario : Scenario
{
    public RotationScenario() : base("Rotation", Color.Black) { }

    public override void Initialize()
    {
        this.AddGameObjects(
            new RectangleRotation(new(300, 200))
        );

        base.Initialize();
    }
}