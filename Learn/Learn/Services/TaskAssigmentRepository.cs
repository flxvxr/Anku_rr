using System.Data;
using Dapper;
using Learn.Models;
using Microsoft.Data.SqlClient;

namespace Learn.Services;

public class TaskAssigmentRepository : ITaskAssigmentService
{
    public string ConnectionString { get; set; }

    public TaskAssigmentRepository(IConfiguration configuration)
    {
        ConnectionString = configuration["ConnectionStrings:DefaultConnection"];
    }

    public List<TaskAssignment> GetTaskAssignments()
    {
        using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
        {
            var taskAssignments = dbConnection.Query<TaskAssignment>("SELECT * FROM TaskAssignments").ToList();
            return taskAssignments;
        }
    }

    public void AddTaskAssignment(TaskAssignment taskAssignment)
    {
        using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
        {
            dbConnection.Execute(
                "INSERT INTO TaskAssignments (AssignmentID, TaskID, EmployeeID, AssignedDate) VALUES (@AssignmentID, @TaskID, @EmployeeID, @AssignedDate)",
                taskAssignment);
        }
    }

    public bool UpdateTaskAssignment(TaskAssignment taskAssignment)
    {
        using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
        {
            try
            {
                dbConnection.Execute(
                    "UPDATE TaskAssignments SET AssignedDate = @AssignedDate, TaskID = @TaskID, EmployeeID = @EmployeeID WHERE AssignmentID = @AssignmentID",
                    taskAssignment);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }

    public void DeleteTaskAssignment(TaskAssignment taskAssignment)
    {
        using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
        {
            dbConnection.Execute("DELETE FROM TaskAssignments WHERE AssignmentID = @AssignmentID",
                new { AssignmentID = taskAssignment.AssignmentID });
        }
    }
}