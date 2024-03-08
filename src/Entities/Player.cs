using Microsoft.Xna.Framework;
using Library.Esliph.Common;
using Library.Esliph.Sprites;
using Pong.Global;

namespace Pong.Entities;

public class Player : GameObject
{
    public float speed { get; set; }
    public Player(int x) : base(new RectangleSprite(new(x, (GameGlobals.WINDOW_DIMENSION.Height - GameGlobals.PLAYER_DIMENSION.Height) / 2), GameGlobals.PLAYER_DIMENSION, 0, null, Color.White))
    {
        this.speed = GameGlobals.PLAYER_SPEED;
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }

    public void MoveUp(GameTime gameTime)
    {

    }
}