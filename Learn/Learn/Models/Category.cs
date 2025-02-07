namespace Learn.Models;

public class Category
{
    public int CategoryID { get; set; }
    
    public string NameCategory { get; set; }
    
    public string CategoryDescription { get; set; }

    public List<TTask> Tasks { get; set; }
}