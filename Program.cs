using Pong;

namespace ProgramCore;

public class Program
{
    static App game;

    public static void Main(string[] args)
    {
        Program.StartGame();
    }

    private static void StartGame()
    {
        Program.game = new();

        game.Run();
    }
}