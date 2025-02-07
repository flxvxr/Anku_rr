namespace Learn.Models;

public class TTask
{
    public int TaskID { get; set; }
    
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public int CategoryID { get; set; }
    
    public Category Category { get; set; }
    
    public DateTime CreatedDate { get; set; }
    
    public DateTime DueDate { get; set; }
    
    public string TaskStatus { get; set; }

    public List<TaskAssignment> TaskAssignments { get; set; }
}