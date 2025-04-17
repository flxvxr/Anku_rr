namespace AbstractFactory;

public class ConsoleUpperCaseWriter: IConsoleWriter
{
    public void Write(string message)
    {
        message = message.ToUpper();
        Console.WriteLine(message);
    }
}