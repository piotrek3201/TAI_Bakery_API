using Microsoft.EntityFrameworkCore;
using WebApp.Model;

namespace WebApp.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDBContext db;

        public OrderRepository(AppDBContext db)
        {
            this.db = db;
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await db.Orders.ToListAsync();
        }

        public async Task<List<OrderDetail>> GetOrderDetailsAsync(long orderId)
        {
            var orderDetails = await db.OrderDetails.Where(x => x.OrderId == orderId).ToListAsync();
            if(orderDetails != null)
            {
                foreach(var orderDetail in orderDetails)
                {
                    orderDetail.Product = await db.Products.FirstOrDefaultAsync(x => x.ProductId == orderDetail.ProductId);
                }
            }
            return orderDetails;
        }

        public async Task<bool> AddOrderAsync(Order order)
        {
            var maxId = await db.Orders.MaxAsync(x => x.OrderId);

            if (maxId > 0)
                order.OrderId = maxId + 1;
            else
                order.OrderId = 0;

            try 
            {
                var orderDetails = order.OrderDetails;
                var orderValue = 0M;
                if(orderDetails != null)
                {
                    foreach(var orderDetail in orderDetails)
                    {
                        var product = await db.Products.FirstOrDefaultAsync(x => x.ProductId == orderDetail.ProductId);
                        if(product != null)
                        {
                            var productPrice = product.Price;
                            orderDetail.Price = productPrice * (decimal)orderDetail.Quantity;

                            orderValue += orderDetail.Price;
                        } 
                    }
                }
                order.OrderValue = orderValue;
                await db.Orders.AddAsync(order);
                if(orderDetails != null)
                {
                    foreach (var orderDetail in orderDetails)
                    {
                        orderDetail.OrderId = maxId + 1;
                        if(orderDetail.Product != null)
                            orderDetail.Price = orderDetail.Product.Price * (decimal)orderDetail.Quantity;
                        await db.OrderDetails.AddAsync(orderDetail);
                    }
                }
                
                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Order> GetOrderByIdAsync(long orderId)
        {
            var order = await db.Orders.FirstOrDefaultAsync(x => x.OrderId == orderId);
            if (order != null)
            {
                order.OrderDetails = await GetOrderDetailsAsync(orderId);
            }
            return order;
        }
    }
}
