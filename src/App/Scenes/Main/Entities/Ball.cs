using Microsoft.Xna.Framework;
using Library.Esliph.Shapes;
using Library.Esliph.Common;
using Library.Esliph.Components;
using Pong.Global;

namespace Pong.Scenes.Main.Entities;

public class Ball : GameObject, IColliderComponentObject
{
    private float speed { get; set; }
    private Vector2 direction;

    public Ball() : base()
    {
        this.direction = new(1, 1);
        this.speed = GlobalGame.BALL_SPEED;
        this.AddTags("Entity", "Ball");
        this.AddComponents(
            new CircleShape2D(new(GlobalGame.WINDOW_DIMENSION.Width / 2, GlobalGame.WINDOW_DIMENSION.Height / 2),
            GlobalGame.BALL_RADIUS, null, 0, null, Color.White),
            new CircleCollider2DComponent(this)
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
        if (gameObject.CompareTo("_MAP"))
        {
            if (this.GetShape2D().InitialY <= 0 || this.GetShape2D().EndY >= gameObject.GetComponent<RectangleShape2D>().Height)
            {
                this.direction.Y *= -1;
            }
            if (this.GetShape2D().InitialX <= 0 || this.GetShape2D().EndX >= gameObject.GetComponent<RectangleShape2D>().Width)
            {
                this.direction.X *= -1;
            }
        }
    }

    public Vector2 GetDirection()
    {
        return this.direction;
    }

    public CircleShape2D GetShape2D()
    {
        return this.GetShape2D<CircleShape2D>();
    }
}