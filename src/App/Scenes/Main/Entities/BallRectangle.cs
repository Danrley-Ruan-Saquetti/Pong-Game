using Microsoft.Xna.Framework;
using Library.Esliph.Common;
using Library.Esliph.Components;
using Library.Esliph.Components.GameObjects;
using Pong.Global;
using Library.Esliph.Shapes;

namespace Pong.Scenes.Main.Entities;

public class BallRectangle : RectangleGameObject, IColliderComponentObject
{
    private float speed { get; set; }
    private Vector2 direction;

    public BallRectangle() : base(new((GlobalGame.WINDOW_DIMENSION.Width - (GlobalGame.BALL_RADIUS * 2)) / 2, (GlobalGame.WINDOW_DIMENSION.Height - GlobalGame.PLAYER_DIMENSION.Height) / 2), new(GlobalGame.BALL_RADIUS * 2, GlobalGame.BALL_RADIUS * 2))
    {
        this.direction = new(1, 1);
        this.speed = GlobalGame.BALL_SPEED;
        this.AddTags("Entity", "Ball");
        this.AddComponents(
            new RectangleCollider2DComponent(this)
        );

        this.GetShape2D().SetColor(Color.White);
    }

    public override void Update()
    {
        this.MoveBall();
        base.Update();
    }

    public void MoveBall()
    {
        float deltaSpeed = this.speed * (float)this.gameController.GetGameTime().ElapsedGameTime.TotalSeconds;

        this.GetShape2D().X += (int)(this.direction.X * deltaSpeed);
        this.GetShape2D().Y += (int)(this.direction.Y * deltaSpeed);
    }

    public void OnCollisionEnter(IGameObject gameObject)
    {
        if (gameObject.CompareTo("Player"))
        {
            this.direction.X *= -1;
        }
        else if (gameObject.CompareTo("_MAP"))
        {
            if (this.GetShape2D().Y <= 0 || this.GetShape2D().EndY >= gameObject.GetComponent<RectangleShape2D>().Height)
            {
                this.direction.Y *= -1;
            }
            if (this.GetShape2D().X <= 0 || this.GetShape2D().EndX >= gameObject.GetComponent<RectangleShape2D>().Width)
            {
                this.direction.X *= -1;
            }
        }
        if (gameObject.CompareTo("WallScore"))
        {
            WriteLine("Score");
        }
    }

    public Vector2 GetDirection()
    {
        return this.direction;
    }
}