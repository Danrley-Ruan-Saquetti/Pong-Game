using System;
using Microsoft.Xna.Framework.Graphics;

namespace Pong.Global;

public enum Sides
{
    Right = 1,
    Left = -1,
    Center = 0
}

public class Globals
{
    public static Random random = new();
    public static SpriteBatch spriteBatch;
    public static int
     WINDOW_WIDTH = 850,
     WINDOW_HEIGHT = 450,
     RACKET_WIDTH = 15,
     RACKET_HEIGHT = (int)450 / 4,
     BALL_SIZE = 17,
     RACKET_GAP_BOARD = 20;
    public static float PLAYER_SPEED = 300f, BALL_SPEED = 450f;
    public static Texture2D pixel;
}