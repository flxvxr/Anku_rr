namespace AbstractFactory;

public class GreenConsoleWriter: IConsoleWriter
{
    public void Write(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}