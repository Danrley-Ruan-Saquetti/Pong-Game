using System;
using Pong;

namespace Prong.Program;

public class Program
{
    private static App game;

    [STAThread]
    public static void Main(string[] args)
    {
        StartGame();
    }

    private static void StartGame()
    {
        game = new App();
        game.Run();
    }
}