using Library.Esliph.Common;
using Microsoft.Xna.Framework;
using Pong.Entities;
using Pong.Global;

namespace Pong.Scenarios;

public class MainScenario : Scenario
{
    public MainScenario() : base("Main", Color.Black) { }

    public override void Initialize()
    {
        int gap = 15;

        var ball = new Ball();

        this.AddGameObjects(
            new PlayerUser(PlayerSide.LEFT, gap),
            new PlayerCPU(PlayerSide.RIGHT, GameGlobals.WINDOW_DIMENSION.Width - GameGlobals.PLAYER_DIMENSION.Width - gap, ball),
            ball
        );

        base.Initialize();
    }
}