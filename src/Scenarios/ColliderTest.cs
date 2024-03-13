using Microsoft.Xna.Framework;
using Library.Esliph.Common;
using Test.Entities;

namespace Pong.Scenarios;

public class ColliderTestScenario : Scenario
{
    public ColliderTestScenario() : base("ColliderTest", Color.Black) { }

    public override void Initialize()
    {
        this.AddGameObjects(
            new RectangleTestCollision(10, 1),
            new RectangleTestCollision(200, -1)
        );

        base.Initialize();
    }
}