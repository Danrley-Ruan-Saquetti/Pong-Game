using Microsoft.Xna.Framework;
using Library.Esliph.Common;
using Test.Entities;

namespace Pong.Scenarios;

public class MultipleCircles : Scenario
{
    public MultipleCircles() : base("MultipleCircles", Color.Black) { }

    public override void Initialize()
    {
        CircleTestCollision1[] circles = new CircleTestCollision1[10];

        for (int i = 0; i < circles.Length; i++)
        {
            circles[i] = new();
        }

        this.AddGameObjects(circles);

        base.Initialize();
    }
}