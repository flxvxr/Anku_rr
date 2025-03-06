using System.Data;
using Dapper;
using Learn.Models;
using Microsoft.Data.SqlClient;

namespace Learn.Services;

public class CategoryRepository: ICategoryService
{
    public string ConnectionString = null;

    public CategoryRepository(IConfiguration configuration)
    {
        ConnectionString = configuration.GetConnectionString("DefaultConnection");
    }
    
    public List<Category> GetAllCategories()
    {
        using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
        {
            var categories = dbConnection.Query<Category>("SELECT * FROM Categories").ToList();
            var tasks = dbConnection.Query<TTask>("SELECT * FROM Tasks").ToList();
            foreach (var category in categories)
            {
                category.Tasks = tasks.Where(x => x.CategoryID == category.CategoryID).ToList();
            }
            return categories;
        }
    }

    public void AddCategory(Category category)
    {
        using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
        {
            dbConnection.Execute("INSERT INTO Categories (CategoryName, CategoryDescription) VALUES (@CategoryName, @CategoryDescription)", category);
        }
    }
}