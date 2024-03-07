using System.IO;

namespace Chess.Services;

public class Log
{
    private static string FILE_PATH = Path.Combine("output", "output.log");

    public static void Print(string content)
    {
        using (StreamWriter outputFile = new(Log.FILE_PATH, true))
        {
            outputFile.WriteLine(content);
        }
    }
}