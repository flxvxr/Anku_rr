using Learn.Models;

namespace Learn.Services;

public interface ICategoryService
{
    public List<Category> GetAllCategories();

    public void AddCategory(Category category);
}