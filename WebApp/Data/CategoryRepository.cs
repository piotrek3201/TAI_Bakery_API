using Microsoft.EntityFrameworkCore;
using WebApp.Model;

namespace WebApp.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDBContext db;

        public CategoryRepository(AppDBContext db)
        {
            this.db = db;
        }

        public async Task<bool> AddCategoryAsync(Category category)
        {
            try
            {
                await db.Categories.AddAsync(category);
                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await db.Categories.ToListAsync();
        }
    }
}
