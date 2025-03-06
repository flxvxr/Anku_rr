using System.Data;
using Dapper;
using Learn.Models;
using Microsoft.Data.SqlClient;

namespace Learn.Services;

public class TaskRepository: ITaskService
{
    public string ConnectionString { get; set; }

    public TaskRepository(IConfiguration configuration)
    {
        ConnectionString = configuration["ConnectionString"];
    }
    
    public List<TTask> GetTasks()
    {
        using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
        {
            var tasks = dbConnection.Query<TTask>("SELECT * FROM Categories").ToList();
            var taskAssignments = dbConnection.Query<TaskAssignment>("SELECT * FROM TaskAssignments").ToList();
            foreach (var task in tasks)
            {
                task.TaskAssignments = taskAssignments.Where(x => x.TaskID == task.TaskID).ToList();
            }
            return tasks;
        }
    }

    public void AddTask(TTask task)
    {
        using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
        {
            dbConnection.Execute("INSERT INTO Tasks (Title, Description, CategoryId, CreatedDate, DueDate, TaskStatus) VALUES (@Title, @Description, @CategoryId, @CreatedDate, @DueDate, @TaskStatus)", task);
        }
    }
}