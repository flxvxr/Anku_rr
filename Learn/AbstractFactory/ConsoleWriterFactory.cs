namespace AbstractFactory;

public class ConsoleWriterFactory
{
    public IConsoleWriter Create()
    {
        ConsoleWriter consoleWriter1 = new ConsoleWriter(null);
        RedConsoleWriter redConsoleWriter = new RedConsoleWriter(consoleWriter1);
        ConsoleWriter consoleWriter2 = new ConsoleWriter(redConsoleWriter);
        BlueConsoleWriter blueConsoleWriter = new BlueConsoleWriter(consoleWriter2);
        ConsoleWriter consoleWriter3 = new ConsoleWriter(blueConsoleWriter);
        return consoleWriter3;
    }
}