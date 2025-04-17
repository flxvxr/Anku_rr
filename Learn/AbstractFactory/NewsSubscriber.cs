namespace AbstractFactory;

public class NewsSubscriber
{
    NewsBureau _newsBureau;
    private readonly ConsoleWriterFactory _consoleWriterFactory;

    public NewsSubscriber(NewsBureau newsBureau, ConsoleWriterFactory consoleWriterFactory)
    {
        _newsBureau = newsBureau;
        _consoleWriterFactory = consoleWriterFactory;
        
        _newsBureau.ReleaseNewsEvent += ReadNews;
    }
    
    void ReadNews(string news)
    {
        IConsoleWriter consoleWriter = _consoleWriterFactory.Create();
        consoleWriter.Write($"Я получил новость: {news}");
    }
}