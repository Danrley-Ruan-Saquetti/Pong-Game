using Microsoft.Xna.Framework;
using Library.Esliph.Common;
using Library.Esliph.Sprites;
using Pong.Global;
using Microsoft.Xna.Framework.Input;

namespace Pong.Entities;

public class Player : GameObject<RectangleSprite>
{
    public float speed { get; set; }
    public Player(float x = 0) : this((int)x) { }
    public Player(int x) : base(new RectangleSprite(new(x, (GameGlobals.WINDOW_DIMENSION.Height - GameGlobals.PLAYER_DIMENSION.Height) / 2), GameGlobals.PLAYER_DIMENSION, 0, null, Color.White))
    {
        this.speed = GameGlobals.PLAYER_SPEED;
    }

    public override void Update(GameTime gameTime)
    {
        this.MovePlayer(gameTime);
        base.Update(gameTime);
    }

    public virtual void MovePlayer(GameTime gameTime) { }

    public void MoveUp(GameTime gameTime)
    {
        this.GetSprite().Y -= GameGlobals.CalcDistanceMove(this.speed, (float)gameTime.ElapsedGameTime.TotalSeconds);
    }

    public void MoveDown(GameTime gameTime)
    {
        this.GetSprite().Y += GameGlobals.CalcDistanceMove(this.speed, (float)gameTime.ElapsedGameTime.TotalSeconds);
    }
}