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
        // Coordenadas dos pontos
        double x1 = 900;
        double y1 = 207;
        double x2 = 425;
        double y2 = 200;

        // Calcular as diferenças
        double deltaX = x2 - x1;
        double deltaY = y2 - y1;

        // Calcular o arco tangente (em radianos)
        double thetaRadians = Math.Atan2(deltaY, deltaX);

        // Converter radianos para graus
        double thetaDegrees = thetaRadians * (180 / Math.PI);

        Program.StartGame();
        WriteLine("O ângulo em graus é: " + thetaDegrees);
        WriteLine("O ângulo em radianos é: " + thetaRadians);
    }

    private static void StartGame()
    {
        Program.game = new App();
        Program.game.RunOneFrame();
    }
}