namespace AbstractFactory;

public class ConsoleUpperCaseWriter: IConsoleWriter
{
    private IConsoleWriter _consoleWriter;
    
    public ConsoleUpperCaseWriter(IConsoleWriter consoleWriter)
    {
        _consoleWriter = consoleWriter;
    }

    public void Write(string message)
    {
        message = message.ToUpper();
        _consoleWriter.Write(message);
    }
}