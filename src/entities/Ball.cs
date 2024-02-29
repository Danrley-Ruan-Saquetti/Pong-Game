using Pong.Components;
using Microsoft.Xna.Framework;
using System;
using Pong.Global;

namespace Pong.Entities;

public class Ball : BaseRectangle
{
    public float directionX, directionY;

    public Ball(int x, int y) : base(x, y, Globals.BALL_SIZE, Globals.BALL_SIZE, Color.White)
    {

        this.directionY = Globals.random.Next(2) == 1 ? -1 : 1;
    }

    public void Update(GameTime gameTime)
    {
        this.UpdateDirectionsY();
        this.MoveBall((float)gameTime.ElapsedGameTime.TotalSeconds);
    }

    private void MoveBall(float totalSecondsGameTime)
    {
        float deltaSpeed = Globals.BALL_SPEED * totalSecondsGameTime;
        this.rectangle.X += (int)(this.directionX * deltaSpeed);
        this.rectangle.Y += (int)(this.directionY * deltaSpeed);
    }

    private void UpdateDirectionsY()
    {
        if (this.rectangle.Y >= 0 && this.rectangle.Y + this.rectangle.Height <= Globals.WINDOW_HEIGHT)
        {
            return;
        }
        this.DefineDirectionY(this.directionY * -1);
    }

    public void NewDirectionY()
    {
        double newDirection = Globals.random.NextDouble() * (1 - (-1)) + (-1);

        this.DefineDirectionY((float)newDirection);
    }

    public void ToggleDirectionX()
    {
        this.DefineDirectionX(this.directionX * -1);
    }

    public void ToggleDirectionY()
    {
        this.DefineDirectionY(this.directionY * -1);
    }

    public void DefineDirectionX(float value)
    {
        this.directionX = value;
    }

    public void DefineDirectionY(float value)
    {
        this.directionY = value;
    }
}