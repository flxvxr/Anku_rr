using Learn.Models;

namespace Learn.Services;

public interface ITaskService
{
    public List<TTask> GetTasks();

    public void AddTask(TTask task);
}