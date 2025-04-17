namespace AbstractFactory;

public class BlueConsoleWriter: IConsoleWriter
{
    public void Write(string message)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}