using Microsoft.Xna.Framework;
using Library.Esliph.Common;
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

        this.AddGameObject(ball);
        this.AddGameObject(new PlayerUser(PlayerSide.LEFT, gap));
        this.AddGameObject(new PlayerCPU(PlayerSide.RIGHT, GameGlobals.WINDOW_DIMENSION.Width - GameGlobals.PLAYER_DIMENSION.Width - gap, ball));

        base.Initialize();
    }
}