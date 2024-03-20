using Microsoft.Xna.Framework;
using Library.Esliph.Common;
using Library.Esliph.Components;

namespace Pong.Scenes.Pothio.Entities;

public class Enemy : Actor, IColliderComponentObject
{
    private Player player;

    public Enemy(Player player, Vector2 position) : base(position, PothioGlobal.ENEMY_DIMENSION, PothioGlobal.ENEMY_SPEED)
    {
        this.player = player;
        this.AddTags("Enemy");
        this.GetShape2D().SetColor(Color.White);
        this.AddComponents(
            new RectangleCollider2DComponent(this)
        );
    }

    public override void Update()
    {
        this.MoveToPlayer();
        base.Update();
    }

    public void MoveToPlayer()
    {
        this.GetShape2D().MoveTo(
            this.player.GetShape2D().position,
            this.GetSpeed(),
            (float)this.gameController.GetGameTime().TotalGameTime.TotalSeconds
        );
    }

    public void OnCollisionEnter(IGameObject gameObject) { }
}