using Microsoft.Xna.Framework;
using Library.Esliph.Common;
using Library.Esliph.Components;
using Library.Esliph.Components.GameObjects;
using Pong.Global;
using Library.Esliph.Shapes;

namespace Pong.Scenes.Main.Entities;

public class Ball : RectangleGameObject, IColliderComponentObject
{
    private float speed { get; set; }
    private Vector2 direction;

    public Ball() : base(new((GlobalGame.WINDOW_DIMENSION.Width - (GlobalGame.BALL_RADIUS * 2)) / 2, (GlobalGame.WINDOW_DIMENSION.Height - GlobalGame.PLAYER_DIMENSION.Height) / 2), new(GlobalGame.BALL_RADIUS * 2, GlobalGame.BALL_RADIUS * 2))
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

        var shape = this.GetShape2D();

        shape.X += (int)(this.direction.X * deltaSpeed);
        shape.Y += (int)(this.direction.Y * deltaSpeed);
    }

    public void OnCollisionEnter(IGameObject gameObject)
    {
        if (gameObject.CompareTo("Player"))
        {
            this.direction.X *= -1;
        }
        else if (gameObject.CompareTo("_MAP"))
        {
            var shape = this.GetShape2D();

            if (shape.Y <= 0 || shape.EndY >= gameObject.GetComponent<RectangleShape2D>().Height)
            {
                this.direction.Y *= -1;
            }
        }
    }

    public void ResetToInitialPosition()
    {
        this.GetShape2D().position = new((GlobalGame.WINDOW_DIMENSION.Width - (GlobalGame.BALL_RADIUS * 2)) / 2, (GlobalGame.WINDOW_DIMENSION.Height - GlobalGame.PLAYER_DIMENSION.Height) / 2);
    }

    public Vector2 GetDirection()
    {
        return this.direction;
    }
}