using Learn.Models;
using Learn.Services;
using Microsoft.AspNetCore.Mvc;

namespace Learn.Controllers;

public class TaskController : Controller
{
    public ITaskService TaskService { get; set; }
    
    public TaskController(ITaskService taskService)
    {
        TaskService = taskService;
    }

    public List<TTask> GetTasks()
    {
        return TaskService.GetTasks();
    }

    public void AddTask(TTask task)
    {
        TaskService.AddTask(task);
    }
}