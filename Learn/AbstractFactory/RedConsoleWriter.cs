namespace AbstractFactory;

public class RedConsoleWriter: IConsoleWriter
{
    public void Write(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}