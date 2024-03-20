using Microsoft.Xna.Framework;
using Library.Esliph.Common;
using Library.Esliph.Components;
using Pong.Global;

namespace Pong.Scenes.Pothio.Entities;

public class Enemy : Actor, IColliderComponentObject
{
    private Player player;

    public Enemy(Player player) : base(new((GlobalGame.WINDOW_DIMENSION.Width - PothioGlobal.PLAYER_DIMENSION.Width) / 2, (GlobalGame.WINDOW_DIMENSION.Height - PothioGlobal.PLAYER_DIMENSION.Height) / 2), PothioGlobal.PLAYER_DIMENSION, PothioGlobal.PLAYER_SPEED)
    {
        this.player = player;
        this.AddTags("Enemy");
        this.GetShape2D().SetColor(Color.White);
        this.AddComponents(
            new RectangleCollider2DComponent(this)
        );
    }

    public void OnCollisionEnter(IGameObject gameObject) { }
}