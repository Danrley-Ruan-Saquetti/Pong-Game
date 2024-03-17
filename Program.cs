using System;
using Pong;

namespace Prong.Program;

public class Program
{
    private static App game;

    /// <summary>
    /// The main entry point for the application
    /// </summary>
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