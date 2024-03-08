using Library.Esliph.Components;

namespace Pong.Global;

public class GameGlobals
{
    public static Dimension WINDOW_DIMENSION = new(900, 450);
    public static Dimension PLAYER_DIMENSION = new(12, 100);
    public static float PLAYER_SPEED = 400f;

    public static int CalcDistanceMove(float speed, float totalSecondsGameTime)
    {
        return (int)(speed * (float)totalSecondsGameTime);
    }
}