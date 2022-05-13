using WebApp.Model;

namespace WebApp.Data
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetCategoriesAsync();
        Task<bool> AddCategoryAsync(Category category);
    }
}
