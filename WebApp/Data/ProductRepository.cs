using Microsoft.EntityFrameworkCore;
using WebApp.Model;

namespace WebApp.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDBContext db;

        public ProductRepository(AppDBContext db)
        {
            this.db = db;
        }

        public async Task<bool> AddProductAsync(Product product)
        {
            var maxId = await db.Products.MaxAsync(x => x.ProductId);

            if (maxId > 0)
                product.ProductId = maxId + 1;
            else
                product.ProductId = 0;

            try
            {
                await db.Products.AddAsync(product);
                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteProductAsync(long id)
        {
            try
            {
                var productToDelete = await GetProductByIdAsync(id);
                db.Products.Remove(productToDelete);
                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await db.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(long id)
        {
            return await db.Products.FirstOrDefaultAsync(x => x.ProductId == id);
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            try
            {
                db.Products.Update(product);
                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
