using WebApp.Model;

namespace WebApp.Data
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrdersAsync();
        Task<List<OrderDetail>> GetOrderDetailsAsync(long orderId);
        Task<Order> GetOrderByIdAsync(long orderId);
        Task<bool> AddOrderAsync(Order order);
        Task<bool> DeleteOrderAsync(long orderId);
    }
}
