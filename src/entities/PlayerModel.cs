using Microsoft.Xna.Framework;
using Pong.Global;

namespace Pong.Entities;

public class PlayerModel : Racket
{
    public Ball ball;
    public float speed = Globals.PLAYER_SPEED;
    public int sideCode, points = 0;
    public int initialPositionX, initialPositionY;

    public PlayerModel(int x, int y) : base(x, y)
    {
        this.initialPositionX = x;
        this.initialPositionY = y;
    }

    public virtual void Update(GameTime gameTime) { }

    public virtual void FollowTarget(int targetY, double totalSecondsGameTime)
    {
        if (this.ball.directionX != this.sideCode)
        {
            this.MoveToInitialPosition(totalSecondsGameTime);
        }
        this.MoveToTarget(targetY, totalSecondsGameTime);
    }

    public virtual void MoveToInitialPosition(double totalSecondsGameTime)
    {
        var bounds = this.GetBounds();

        if (this.initialPositionY + (bounds.Height / 2) < bounds.PointCenterY)
        {
            this.MoveUp(totalSecondsGameTime);
        }
        else if (this.initialPositionY + (bounds.Height / 2) > bounds.PointCenterY)
        {
            this.MoveDown(totalSecondsGameTime);
        }
        else
        {
            this.rectangle.Y = this.initialPositionY;
        }
    }

    public virtual void MoveToTarget(int targetY, double totalSecondsGameTime)
    {
        var bounds = this.GetBounds();
        int gap = (int)bounds.Height / 3;

        if (targetY <= bounds.PointY + gap)
        {
            this.MoveUp(totalSecondsGameTime);
        }

        if (targetY >= bounds.PointHeight - gap)
        {
            this.MoveDown(totalSecondsGameTime);
        }
    }

    public virtual void MoveUp(double totalSecondsGameTime)
    {
        if (this.IsEnableMoveUp())
        {
            return;
        }

        this.rectangle.Y -= (int)(this.speed * (float)totalSecondsGameTime);
    }

    public virtual void MoveDown(double totalSecondsGameTime)
    {
        if (this.IsEnableMoveDown())
        {
            return;
        }
        this.rectangle.Y += (int)(this.speed * (float)totalSecondsGameTime);
    }

    public bool IsEnableMoveUp()
    {
        return this.rectangle.Y <= 0;
    }

    public bool IsEnableMoveDown()
    {
        return this.rectangle.Y + this.rectangle.Height >= Globals.WINDOW_HEIGHT;
    }

    public void ResetPosition()
    {
        this.rectangle.Y = this.initialPositionY;
        this.rectangle.X = this.initialPositionX;
    }

    public void AddPoint()
    {
        this.points++;
    }
}