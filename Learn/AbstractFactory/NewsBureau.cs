namespace AbstractFactory;

public class NewsBureau
{
    public delegate void ReleaseNewsHandler(string news);
    public event ReleaseNewsHandler ReleaseNewsEvent;
    
    public void ReleaseNews(string news)
    {
        ReleaseNewsEvent?.Invoke(news);
    }
}