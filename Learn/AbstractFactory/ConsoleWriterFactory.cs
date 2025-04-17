namespace AbstractFactory;

public class ConsoleWriterFactory
{
    public IConsoleWriter Create()
    {
        return new ConsoleUpperCaseWriter();
    }
}