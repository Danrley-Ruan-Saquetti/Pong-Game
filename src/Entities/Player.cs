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
    public Vector2 initialPosition;

    public Player(PlayerSide side, float x = 0) : this(side, (int)x) { }
    public Player(PlayerSide side, int x) : base(new RectangleSprite(new(x, (GameGlobals.WINDOW_DIMENSION.Height - GameGlobals.PLAYER_DIMENSION.Height) / 2), GameGlobals.PLAYER_DIMENSION, 0, null, Color.White))
    {
        this.speed = GameGlobals.PLAYER_SPEED;
        this.side = side;
        this.initialPosition = new(x, (GameGlobals.WINDOW_DIMENSION.Height - GameGlobals.PLAYER_DIMENSION.Height) / 2);
        this.AddTags("Entity", "Player");
    }

    public override void Update(GameTime gameTime)
    {
        this.MovePlayer(gameTime);
        base.Update(gameTime);
    }

    public virtual void MovePlayer(GameTime gameTime) { }

    public void MoveUp(GameTime gameTime)
    {
        if (this.GetSprite().Y < 0)
        {
            this.GetSprite().Y = 0;
            return;
        }
        this.GetSprite().Y -= GameGlobals.CalcDistanceMove(this.speed, (float)gameTime.ElapsedGameTime.TotalSeconds);
    }

    public void MoveDown(GameTime gameTime)
    {
        if (this.GetSprite().Y + this.GetSprite().Height > GameGlobals.WINDOW_DIMENSION.Height)
        {
            this.GetSprite().Y = GameGlobals.WINDOW_DIMENSION.Height - this.GetSprite().Height;
            return;
        }
        this.GetSprite().Y += GameGlobals.CalcDistanceMove(this.speed, (float)gameTime.ElapsedGameTime.TotalSeconds);
    }

    public virtual void MoveToInitialPosition(GameTime gameTime)
    {
        if (this.initialPosition.Y > this.GetSprite().Y)
        {
            this.MoveDown(gameTime);
        }
        else if (this.initialPosition.Y > this.GetSprite().Y)
        {
            this.MoveUp(gameTime);
        }
        else
        {
            this.GetSprite().Y = this.initialPosition.Y;
        }
    }
}