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
                    if(orderDetail.Product != null && orderDetail.Product.IsCustomizable)
                    {
                        orderDetail.Customization = await db.Customizations.FirstOrDefaultAsync(x => x.CustomizationId == orderDetail.CustomizationId);
                        
                        if(orderDetail.Customization != null)
                        {
                            orderDetail.Customization.Cake = await db.Cakes.FirstOrDefaultAsync(x => x.CakeId == orderDetail.Customization.CakeId);
                            orderDetail.Customization.Filling = await db.Fillings.FirstOrDefaultAsync(x => x.FillingId == orderDetail.Customization.FillingId);
                            orderDetail.Customization.Glaze = await db.Glazes.FirstOrDefaultAsync(x => x.GlazeId == orderDetail.Customization.GlazeId);
                            orderDetail.Customization.Size = await db.Sizes.FirstOrDefaultAsync(x => x.SizeId == orderDetail.Customization.SizeId);
                            orderDetail.Customization.Addition = await db.Additions.FirstOrDefaultAsync(x => x.AdditionId == orderDetail.Customization.AdditionId);
                        }
                        
                    }
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
                        {
                            orderDetail.Price = orderDetail.Product.Price * (decimal)orderDetail.Quantity;

                            var orderDetailMaxId = await db.OrderDetails.MaxAsync(x => x.OrderDetailId);

                            if(orderDetail.Product.IsCustomizable && orderDetail.Customization != null)
                            {
                                var customizationMaxId = await db.Customizations.MaxAsync(x => x.CustomizationId);
                                orderDetail.CustomizationId = customizationMaxId + 1;
                                orderDetail.Customization.CustomizationId = customizationMaxId + 1; //???
                                await db.Customizations.AddAsync(orderDetail.Customization);
                            }
                        }

                        await db.OrderDetails.AddAsync(orderDetail);
                    }
                }
                
                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception ex)
            { 
                throw ex;
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

        public async Task<bool> DeleteOrderAsync(long orderId)
        {
            try
            {
                var orderToDelete = await GetOrderByIdAsync(orderId);
                db.Orders.Remove(orderToDelete);
                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public async Task<bool> UpdateOrderAsync(Order order)
        {
            try
            {
                db.Orders.Update(order);
                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
