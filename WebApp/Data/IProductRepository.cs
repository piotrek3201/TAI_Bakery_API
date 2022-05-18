using WebApp.Model;

namespace WebApp.Data
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(long id);
        Task<bool> AddProductAsync(Product product);
        Task<bool> UpdateProductAsync(Product product);
        Task<bool> DeleteProductAsync(long id);
        Task<List<Product>> GetProductsByCategoryId(long categoryId);
    }
}
