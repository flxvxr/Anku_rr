using Learn.Models;

namespace Learn.Services;

public interface ITaskAssigmentService
{
    public List<TaskAssignment> GetTaskAssignments();
    
    public void AddTaskAssignment(TaskAssignment taskAssignment);
    
    public bool UpdateTaskAssignment(TaskAssignment taskAssignment);
    
    public void DeleteTaskAssignment(TaskAssignment taskAssignment);
}