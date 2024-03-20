using Microsoft.Xna.Framework;
using Library.Esliph.Common;
using Pong.Scenes.Main.Entities;
using Pong.Global;
using Pong.Scenes.Main.Colliders;
using Pong.Scenes.Main.Fonts;

namespace Pong.Scenes;

public class MainScene : Scene
{
    public MainScene() : base("Main", Color.Black) { }

    public override void Initialize()
    {
        int gap = 15;

        // var ball = new BallCircle();
        var ball = new Ball();
        var player1 = new PlayerUser(PlayerSide.LEFT, gap);
        var player2 = new PlayerCPU(PlayerSide.RIGHT, GlobalGame.WINDOW_DIMENSION.Width - GlobalGame.PLAYER_DIMENSION.Width - gap, ball);

        this.AddGameObjects(
            new Floor(),
            new WallScoreCollider(ball, player1, -1),
            new WallScoreCollider(ball, player2, (int)GlobalGame.WINDOW_DIMENSION.Width),
            ball,
            player1,
            player2,
            new ScoreFont(player1, new(GlobalGame.WINDOW_DIMENSION.Width / 4, GlobalGame.WINDOW_DIMENSION.Height / 5)),
            new ScoreFont(player2, new((int)(GlobalGame.WINDOW_DIMENSION.Width * 0.75), GlobalGame.WINDOW_DIMENSION.Height / 5))
        );

        base.Initialize();
    }
}