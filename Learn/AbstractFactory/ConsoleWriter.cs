namespace AbstractFactory;

public class ConsoleWriter : IConsoleWriter
{
    private IConsoleWriter _consoleWriter;

    public ConsoleWriter(IConsoleWriter consoleWriter)
    {
        _consoleWriter = consoleWriter;
    }

    public void Write(string message)
    {
        Console.WriteLine(message);
        Console.ResetColor();
        
        if (_consoleWriter != null)
        {
            _consoleWriter.Write(message);
        }
    }
}