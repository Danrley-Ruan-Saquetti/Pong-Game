using Microsoft.Xna.Framework;
using Library.Esliph.Common;
using Library.Esliph.Sprites;
using Pong.Global;

public class Ball : GameObject<CircleSprite>
{
    private float speed { get; set; }
    private int direction { get; set; }

    public Ball() : base(
        new(
            new(GameGlobals.WINDOW_DIMENSION.Width / 2, GameGlobals.WINDOW_DIMENSION.Height / 2),
            GameGlobals.BALL_RADIUS
        )
    )
    {
        this.GetSprite().SetColor(Color.White);
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }

    public void MoveBall()
    {

    }
}