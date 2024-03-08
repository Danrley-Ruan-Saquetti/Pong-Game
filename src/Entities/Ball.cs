using Library.Esliph.Common;
using Library.Esliph.Sprites;
using Microsoft.Xna.Framework;
using Pong.Global;

public class Ball : GameObject<CircleSprite>
{
    public Ball() : base(
        new(
            new(GameGlobals.WINDOW_DIMENSION.Width / 2, GameGlobals.WINDOW_DIMENSION.Height / 2),
            GameGlobals.BALL_RADIUS
        )
    )
    {
        this.GetSprite().SetColor(Color.White);
    }
}