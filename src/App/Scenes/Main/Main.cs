using Microsoft.Xna.Framework;
using Library.Esliph.Common;
using Pong.Scenes.Main.Entities;
using Pong.Global;
using Pong.Scenes.Main.Colliders;

namespace Pong.Scenes;

public class MainScene : Scene
{
    public MainScene() : base("Main", Color.Black) { }

    public override void Initialize()
    {
        int gap = 15;

        var ball = new BallRectangle();
        // var ball = new BallCircle();

        this.AddGameObjects(
            new Floor(),
            new WallScoreCollider(-1),
            new WallScoreCollider((int)GlobalGame.WINDOW_DIMENSION.Width),
            ball,
            new PlayerUser(PlayerSide.LEFT, gap),
            new PlayerCPU(PlayerSide.RIGHT, GlobalGame.WINDOW_DIMENSION.Width - GlobalGame.PLAYER_DIMENSION.Width - gap, ball)
        );

        base.Initialize();
    }
}