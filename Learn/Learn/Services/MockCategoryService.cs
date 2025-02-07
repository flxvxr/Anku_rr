using Learn.Models;

namespace Learn.Services;

public class MockCategoryService: ICategoryService
{
    private readonly List<Category> _categories = new List<Category>();
    
    public List<Category> GetAllCategories()
    {
        return _categories;
    }

    public void AddCategory(Category category)
    {
        _categories.Add(category);
    }
}