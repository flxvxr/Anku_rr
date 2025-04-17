namespace AbstractFactory;

public class NewsNotifyer
{
    NewsBureau _newsBureau;
    ConsoleWriterFactory _consoleWriterFactory;

    public NewsNotifyer(NewsBureau newsBureau, ConsoleWriterFactory consoleWriterFactory)
    {
        _newsBureau = newsBureau;
        _consoleWriterFactory = consoleWriterFactory;
        
        _newsBureau.ReleaseNewsEvent += NewsNotify;
    }

    void NewsNotify(String news)
    {
        IConsoleWriter consoleWriter = _consoleWriterFactory.Create();
        consoleWriter.Write($"Внимание, внимание! Новость: {news}");
    }
}