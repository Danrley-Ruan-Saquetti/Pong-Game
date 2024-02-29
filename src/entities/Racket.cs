using Microsoft.Xna.Framework;
using Pong.Components;
using Pong.Global;

namespace Pong.Entities;

public class Racket : BaseRectangle
{
    public Racket(int x, int y) : base(x, y, Globals.RACKET_WIDTH, Globals.RACKET_HEIGHT, Color.White)
    { }
}