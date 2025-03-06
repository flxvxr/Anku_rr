using Learn.Models;
using Learn.Services;
using Microsoft.AspNetCore.Mvc;

namespace Learn.Controllers; 

[ApiController]
[Route("[controller]")]
public class CategoryController : Controller
{
    public ICategoryService CategoryService { get; set; }
    
    public CategoryController(ICategoryService categoryService)
    {
        CategoryService = categoryService;
    }
    
    [HttpGet("GetAllCategories")]
    public List<Category> GetAllCategories()
    {
        return CategoryService.GetAllCategories();
    }
    
    [HttpPut("AddCategory")]
    public void AddCategory(Category category)
    {
        CategoryService.AddCategory(category);
    }
}