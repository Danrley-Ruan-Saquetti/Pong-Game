using Microsoft.Xna.Framework;
using Library.Esliph.Common;
using Pong.Scenes.Main.Entities;
using Pong.Global;

namespace Pong.Scenes;

public class MainScene : Scene
{
    public MainScene() : base("Main", Color.Black) { }

    public override void Initialize()
    {
        int gap = 15;

        var ball = new Ball();

        this.AddGameObjects(
            new Floor(),
            ball,
            new PlayerUser(PlayerSide.LEFT, gap),
            new PlayerCPU(PlayerSide.RIGHT, GlobalGame.WINDOW_DIMENSION.Width - GlobalGame.PLAYER_DIMENSION.Width - gap, ball)
        );

        base.Initialize();
    }
}