using Learn.Models;

namespace Learn.Services;

public interface ITestStreamService
{
    public void GetTestStream(string fileName, string fileSavePath);

    public Task AddTestStreamAsync(string filePath);
}