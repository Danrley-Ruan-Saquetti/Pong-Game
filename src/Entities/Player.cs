using Microsoft.Xna.Framework;
using Library.Esliph.Common;
using Library.Esliph.Sprites;
using Pong.Global;

namespace Pong.Entities;

public enum PlayerSide
{
    LEFT = -1,
    RIGHT = 1
}

public class Player : GameObject<RectangleSprite>
{
    public float speed { get; set; }
    public readonly PlayerSide side;

    public Player(PlayerSide side, float x = 0) : this(side, (int)x) { }
    public Player(PlayerSide side, int x) : base(new RectangleSprite(new(x, (GameGlobals.WINDOW_DIMENSION.Height - GameGlobals.PLAYER_DIMENSION.Height) / 2), GameGlobals.PLAYER_DIMENSION, 0, null, Color.White))
    {
        this.speed = GameGlobals.PLAYER_SPEED;
        this.side = side;
    }

    public override void Update(GameTime gameTime)
    {
        this.MovePlayer(gameTime);
        base.Update(gameTime);
    }

    public virtual void MovePlayer(GameTime gameTime) { }

    public void MoveUp(GameTime gameTime)
    {
        this.GetSprite().Y -= GameGlobals.CalcDistanceMove(this.speed, (float)gameTime.ElapsedGameTime.TotalSeconds);
    }

    public void MoveDown(GameTime gameTime)
    {
        this.GetSprite().Y += GameGlobals.CalcDistanceMove(this.speed, (float)gameTime.ElapsedGameTime.TotalSeconds);
    }
}