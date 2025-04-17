namespace AbstractFactory;

public class BlueConsoleWriter: IConsoleWriter
{
    private IConsoleWriter _consoleWriter;
    
    public BlueConsoleWriter(IConsoleWriter consoleWriter)
    {
        _consoleWriter = consoleWriter;
    }

    public void Write(string message)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        _consoleWriter.Write(message);
    }
}