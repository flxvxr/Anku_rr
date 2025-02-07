using Learn.Models;
using Learn.Services;
using Microsoft.AspNetCore.Mvc;

namespace Learn.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskAssignmentController : Controller
{
    public ITaskAssigmentService TaskAssignment { get; set; }

    public TaskAssignmentController(ITaskAssigmentService taskAssignmentService)
    {
        TaskAssignment = taskAssignmentService;
    }

    [HttpGet("GetTaskAssignment")]
    public List<TaskAssignment> GetTaskAssignments()
    {
        return TaskAssignment.GetTaskAssignments();
    }

    [HttpPut("AddTaskAssignment")]
    public void AddTaskAssignment(TaskAssignment taskAssignment)
    {
        TaskAssignment.AddTaskAssignment(taskAssignment);
    }
    
    [HttpPatch("UpdateTaskAssignment")]
    public IActionResult UpdateTaskAssignment(TaskAssignment taskAssignment)
    {
        bool isUpdated = TaskAssignment.UpdateTaskAssignment(taskAssignment);
        if (!isUpdated)
        {
            return BadRequest();
        }

        return Ok();
    }

    [HttpDelete("DeleteTaskAssignment")]
    public void DeleteTaskAssignment(TaskAssignment taskAssignment)
    {
        TaskAssignment.DeleteTaskAssignment(taskAssignment);
    }
}