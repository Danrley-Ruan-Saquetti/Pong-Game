using Microsoft.Xna.Framework;
using Library.Esliph.Common;
using Library.Esliph.Shapes;
using Pong.Global;

namespace Pong.Scenarios.Main.Entities;

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
        this.speed = GlobalGame.PLAYER_SPEED;
        this.side = side;
        this.initialPosition = new(x, (GlobalGame.WINDOW_DIMENSION.Height - GlobalGame.PLAYER_DIMENSION.Height) / 2);
        this.AddTags("Entity", "Player");
        this.AddComponents(
            new RectangleShape2D(new(x, (GlobalGame.WINDOW_DIMENSION.Height - GlobalGame.PLAYER_DIMENSION.Height) / 2), GlobalGame.PLAYER_DIMENSION, 0, null, Color.White)
        );
    }

    public override void Start()
    {
        this.score = 0;

        base.Start();
    }

    public override void Update()
    {
        this.MovePlayer();
        base.Update();
    }

    public virtual void MovePlayer() { }

    public void MoveUp()
    {
        if (this.GetShape2D().Y < 0)
        {
            this.GetShape2D().Y = 0;
            return;
        }
        this.GetShape2D().Y -= GlobalGame.CalcDistanceMove(this.speed, (float)this.gameController.GetGameTime().ElapsedGameTime.TotalSeconds);
    }

    public void MoveDown()
    {
        if (this.GetShape2D().Y + this.GetShape2D().Height > GlobalGame.WINDOW_DIMENSION.Height)
        {
            this.GetShape2D().Y = GlobalGame.WINDOW_DIMENSION.Height - this.GetShape2D().Height;
            return;
        }
        this.GetShape2D().Y += GlobalGame.CalcDistanceMove(this.speed, (float)this.gameController.GetGameTime().ElapsedGameTime.TotalSeconds);
    }

    public virtual void MoveToInitialPosition()
    {
        if (this.initialPosition.Y > this.GetShape2D().Y)
        {
            this.MoveDown();
        }
        else if (this.initialPosition.Y < this.GetShape2D().Y)
        {
            this.MoveUp();
        }
        else
        {
            this.GetShape2D().Y = this.initialPosition.Y;
        }
    }

    public RectangleShape2D GetShape2D()
    {
        return this.GetShape2D<RectangleShape2D>();
    }
}