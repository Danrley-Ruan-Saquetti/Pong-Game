using Pong;

public class Program
{
    private static App game;

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