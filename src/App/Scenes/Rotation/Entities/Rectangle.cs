using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Library.Esliph.Common;
using Library.Esliph.Shapes;
using Library.Esliph.Components;
using Pong.Global;
using Library.Esliph.Common.Stats;

namespace Pong.Scenes.Rotation.Entities;

public class RectangleRotation : GameObject, IKeyEventComponentObject
{
    public float speed { get; set; }
    public RectangleShape2D shape { get { return this.GetShape2D<RectangleShape2D>(); } }

    public RectangleRotation(Vector2 position) : base()
    {
        this.speed = 200;
        this.AddTags("Entity", "Rectangle");
        this.AddComponents(
            new RectangleShape2D(position, new(50), 0, null, Color.White),
            new KeyEventComponent(this)
        );
    }

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        this.MoveRectangle();
        base.Update();
    }

    public virtual void MoveRectangle() { }

    public void OnKeyDown(KeyEvent keyEvent)
    {
        if (keyEvent.IsKeyDown(Keys.W))
            this.MoveUp();
        else if (keyEvent.IsKeyDown(Keys.S))
            this.MoveDown();
        if (keyEvent.IsKeyDown(Keys.A))
            this.MoveLeft();
        else if (keyEvent.IsKeyDown(Keys.D))
            this.MoveRight();
    }

    public void MoveLeft()
    {
        if (this.shape.X < 0)
        {
            this.shape.X = 0;
            return;
        }
        this.shape.X -= GlobalGame.CalcDistanceMove(this.speed, (float)this.gameController.GetGameTime().ElapsedGameTime.TotalSeconds);
    }

    public void MoveRight()
    {
        if (this.shape.X + this.shape.Width > GlobalGame.WINDOW_DIMENSION.Width)
        {
            this.shape.X = GlobalGame.WINDOW_DIMENSION.Width - this.shape.Width;
            return;
        }
        this.shape.X += GlobalGame.CalcDistanceMove(this.speed, (float)this.gameController.GetGameTime().ElapsedGameTime.TotalSeconds);
    }

    public void MoveUp()
    {
        if (this.shape.Y < 0)
        {
            this.shape.Y = 0;
            return;
        }
        this.shape.Y -= GlobalGame.CalcDistanceMove(this.speed, (float)this.gameController.GetGameTime().ElapsedGameTime.TotalSeconds);
    }

    public void MoveDown()
    {
        if (this.shape.Y + this.shape.Height > GlobalGame.WINDOW_DIMENSION.Height)
        {
            this.shape.Y = GlobalGame.WINDOW_DIMENSION.Height - this.shape.Height;
            return;
        }
        this.shape.Y += GlobalGame.CalcDistanceMove(this.speed, (float)this.gameController.GetGameTime().ElapsedGameTime.TotalSeconds);
    }

    public RectangleShape2D GetShape2D()
    {
        return this.GetShape2D<RectangleShape2D>();
    }
}