using Library.Esliph.Common;
using Library.Esliph.Components;
using Library.Esliph.Components.GameObjects;
using Pong.Global;
using Pong.Scenes.Main.Entities;

namespace Pong.Scenes.Main.Colliders;

public class WallScoreCollider : RectangleGameObject, IColliderComponentObject
{
    private Player player;
    private Ball ball;

    public WallScoreCollider(Ball ball, Player player, int x) : base(new(x, 0), new(1, GlobalGame.WINDOW_DIMENSION.Height))
    {
        this.ball = ball;
        this.player = player;
        this.AddTags("WallScore");
        this.AddComponents(
            new RectangleCollider2DComponent(this)
        );
    }

    public void OnCollisionEnter(IGameObject gameObject)
    {
        if (gameObject.CompareTo("Ball"))
        {
            this.player.score++;
            this.player.ResetToInitialPosition();
            this.ball.ResetToInitialPosition();
        }
    }
}