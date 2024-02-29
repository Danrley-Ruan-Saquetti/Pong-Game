using Pong;
using Pont.Services;

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
        Log.Print("# Starting...");

        Program.game = new();

        game.Run();
        Log.Print("# Finish");
    }
}