using Microsoft.AspNetCore.Mvc;
using Nortwind_API.DTO;
using Nortwind_API.Models;
using Nortwind_API.UnitOfWork;

namespace Nortwind_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderControler : ControllerBase
    {
        private readonly NorthwindContext context;
        private readonly UnitOfWorkNorthwindSQL unitOfWorkNorthwindSQL;
        public OrderControler()
        {
            context = new NorthwindContext();
            unitOfWorkNorthwindSQL = new UnitOfWorkNorthwindSQL(context);
        }
        [HttpGet]
        public async Task<IList<OrderDTO>> GetOrders()
        {
            IList<Order> orders = await unitOfWorkNorthwindSQL.OrdersRepository.GetAllAsync();
            return orders.Select(o => orderToOrderDTO(o)).ToList();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> GetOneOrder(int id)
        {
           Order order = await unitOfWorkNorthwindSQL.OrdersRepository.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(orderToOrderDTO(order));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderDTO>> DeleteOne(int id)
        {
            Order order = await unitOfWorkNorthwindSQL.OrdersRepository.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            await unitOfWorkNorthwindSQL.OrdersRepository.DeleteAsync(order);
            return Ok(orderToOrderDTO(order));
        }
        [HttpPut]
        public async Task<ActionResult> updateOne(OrderDTO orderDTO)
        {
            Console.WriteLine(orderDTO.EmployeeId);
            Order order = orderDtoToOrder(orderDTO);
            Console.WriteLine(order.EmployeeId);
            await unitOfWorkNorthwindSQL.OrdersRepository.SaveAsync(order);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> InsertOrder(OrderDTO orderDTO)
        {
            Order order = orderDtoToOrder(orderDTO);
            await unitOfWorkNorthwindSQL.OrdersRepository.SaveAsync(order);
            return Ok();
        }
        private static OrderDTO orderToOrderDTO(Order order) =>
            new OrderDTO
            {
                OrderId = order.OrderId,
                OrderDate = order.OrderDate,
                EmployeeId = order.EmployeeId,

            };
        private static Order orderDtoToOrder(OrderDTO orderDTO) =>
            new Order
            {
                OrderId = orderDTO.OrderId,
                OrderDate = orderDTO.OrderDate,
                EmployeeId = orderDTO.EmployeeId,
            };
    }
}
