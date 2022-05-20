using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Data;
using WebApp.Model;

namespace WebApp.Controllers
{
    [Route("api/orders")]
    [ApiController]
    [Tags("Orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        //GET: api/orders/all
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders()
        {
            return await orderRepository.GetAllOrdersAsync();
        }
        //GET: api/orders/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderById(long id)
        {
            return await orderRepository.GetOrderByIdAsync(id);
        }

        //POST: api/orders/add
        [HttpPost("add")]
        public async Task<ActionResult> AddOrder(Order order)
        {
            bool addSuccesful = await orderRepository.AddOrderAsync(order);
            if (addSuccesful)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        //PUT: api/orders/update
        [HttpPut("update")]
        public async Task<ActionResult> UpdateOrder(Order order)
        {
            bool updateSuccesful = await orderRepository.UpdateOrderAsync(order);
            if (updateSuccesful)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        //DELETE: api/orders/delete/{id}
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteOrder(long id)
        {
            bool deleteSuccesful = await orderRepository.DeleteOrderAsync(id);
            if (deleteSuccesful)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}