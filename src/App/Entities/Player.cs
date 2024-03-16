using Microsoft.Xna.Framework;
using Library.Esliph.Common;
using Library.Esliph.Sprite2Ds;
using Pong.Global;

namespace Pong.Entities;

public enum PlayerSide
{
    LEFT = -1,
    RIGHT = 1
}

public class Player : GameObject
{
    public float speed { get; set; }
    public int score;
    public readonly PlayerSide side;
    public Vector2 initialPosition;

    public Player(PlayerSide side, float x = 0) : this(side, (int)x) { }
    public Player(PlayerSide side, int x) : base()
    {
        this.speed = GameGlobals.PLAYER_SPEED;
        this.side = side;
        this.initialPosition = new(x, (GameGlobals.WINDOW_DIMENSION.Height - GameGlobals.PLAYER_DIMENSION.Height) / 2);
        this.AddTags("Entity", "Player");
        this.AddComponents(
            new RectangleSprite2D(new(x, (GameGlobals.WINDOW_DIMENSION.Height - GameGlobals.PLAYER_DIMENSION.Height) / 2), GameGlobals.PLAYER_DIMENSION, 0, null, Color.White)
        );
    }

    public override void Start()
    {
        this.score = 0;

        base.Start();
    }

    public override void Update(GameTime gameTime)
    {
        this.MovePlayer(gameTime);
        base.Update(gameTime);
    }

    public virtual void MovePlayer(GameTime gameTime) { }

    public void MoveUp(GameTime gameTime)
    {
        if (this.GetSprite2D().Y < 0)
        {
            this.GetSprite2D().Y = 0;
            return;
        }
        this.GetSprite2D().Y -= GameGlobals.CalcDistanceMove(this.speed, (float)gameTime.ElapsedGameTime.TotalSeconds);
    }

    public void MoveDown(GameTime gameTime)
    {
        if (this.GetSprite2D().Y + this.GetSprite2D().Height > GameGlobals.WINDOW_DIMENSION.Height)
        {
            this.GetSprite2D().Y = GameGlobals.WINDOW_DIMENSION.Height - this.GetSprite2D().Height;
            return;
        }
        this.GetSprite2D().Y += GameGlobals.CalcDistanceMove(this.speed, (float)gameTime.ElapsedGameTime.TotalSeconds);
    }

    public virtual void MoveToInitialPosition(GameTime gameTime)
    {
        if (this.initialPosition.Y > this.GetSprite2D().Y)
        {
            this.MoveDown(gameTime);
        }
        else if (this.initialPosition.Y > this.GetSprite2D().Y)
        {
            this.MoveUp(gameTime);
        }
        else
        {
            this.GetSprite2D().Y = this.initialPosition.Y;
        }
    }

    public RectangleSprite2D GetSprite2D()
    {
        return this.GetSprite2D<RectangleSprite2D>();
    }
}