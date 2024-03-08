using Library.Esliph.Common;
using Library.Esliph.Sprites;
using Microsoft.Xna.Framework;
using Pong.Global;

namespace Pong.Entities;

public class Player : GameObject
{
    public Player(int x) : base(new RectangleSprite(new(x, (GameGlobals.WINDOW_DIMENSION.Height - GameGlobals.PLAYER_DIMENSION.Height) / 2), GameGlobals.PLAYER_DIMENSION, 0, null, Color.White)) { }
}