namespace AbstractFactory;

public class RedConsoleWriter: IConsoleWriter
{
    private IConsoleWriter _consoleWriter;

    public RedConsoleWriter(IConsoleWriter consoleWriter)
    {
        _consoleWriter = consoleWriter;
    }

    public void Write(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        _consoleWriter.Write(message);
    }
}