namespace Learn.Models;

public class TaskAssignment
{
    public int AssignmentID { get; set; }
    
    public int TaskID { get; set; }

    public int EmployeeID { get; set; }

    public DateTime AssignedDate { get; set; }
}