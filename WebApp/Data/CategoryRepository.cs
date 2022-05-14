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
            var maxId = await db.Categories.MaxAsync(x => x.CategoryId);

            if(maxId > 0)
                category.CategoryId = maxId + 1;
            else
                category.CategoryId = 0;

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

        public async Task<bool> DeleteCategoryAsync(long id)
        {
            try 
            {
                var categoryToDelete = await GetCategoryByIdAsync(id);
                db.Categories.Remove(categoryToDelete);
                return await db.SaveChangesAsync() >= 1;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await db.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(long id)
        {
            return await db.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            try
            {
                db.Categories.Update(category);
                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
