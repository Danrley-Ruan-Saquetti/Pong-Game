using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Library.Esliph.Common;
using Library.Esliph.Components;
using Library.Esliph.Common.Stats;
using Pong.Global;

namespace Pong.Scenes.Pothio.Entities;

public class Player : Actor, IColliderComponentObject, IKeyEventComponentObject
{
    public Player() : base(new((GlobalGame.WINDOW_DIMENSION.Width - PothioGlobal.PLAYER_DIMENSION.Width) / 2, (GlobalGame.WINDOW_DIMENSION.Height - PothioGlobal.PLAYER_DIMENSION.Height) / 2), PothioGlobal.PLAYER_DIMENSION, PothioGlobal.PLAYER_SPEED)
    {
        this.AddTags("Player");
        this.GetShape2D().SetColor(Color.White);
        this.AddComponents(
            new RectangleCollider2DComponent(this),
            new KeyEventComponent(this)
        );
    }

    public void OnCollisionEnter(IGameObject gameObject) { }

    public void OnKeyDown(KeyEvent keyEvent)
    {
        if (keyEvent.IsKeyDown(Keys.A))
        {
            this.MoveToLeft();
        }
        else if (keyEvent.IsKeyDown(Keys.D))
        {
            this.MoveToRight();
        }
        if (keyEvent.IsKeyDown(Keys.W))
        {
            this.MoveToUp();
        }
        else if (keyEvent.IsKeyDown(Keys.S))
        {
            this.MoveToDown();
        }
    }
}