using Microsoft.AspNetCore.Mvc;
using Nortwind_API.DTO;
using Nortwind_API.Models;
using Nortwind_API.UnitOfWork;

namespace Nortwind_API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly NorthwindContext _northwindContext;
        private readonly IUnitOfWork _unitOfWork;

        private readonly ILogger<EmployeController> _logger;

       public OrderController(ILogger<EmployeController> logger)
        {
            _logger = logger;
            _northwindContext = new NorthwindContext();
            _unitOfWork = new UnitOfWorkNorthwindSQL(_northwindContext);
        }

        [HttpGet]
        public async Task<ActionResult<IList<OrderDTO>>> getAllOrder()
        {
            IList<Order> list = await _unitOfWork.OrdersRepository.GetAllAsync();
            if (list == null) return NoContent();
            return Ok(list.Select(e => orderToDTO(e)).ToList());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> getOneOrder(int id)
        {
            Order order = await _unitOfWork.OrdersRepository.GetByIdAsync(id);
            if (order == null) return NotFound();
            return Ok(orderToDTO(order));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteOneOrder(int id)
        {
            Order order = await _unitOfWork.OrdersRepository.GetByIdAsync(id);
            if (order == null) return NotFound();
            await _unitOfWork.OrdersRepository.DeleteAsync(order);
            return Ok("deleted");
        }
        [HttpPost]
        public async Task createOne(OrderDTO orderDTO)
        {
            orderDTO.OrderId = 0;
            Order order = dtoToOrder(orderDTO);
            await _unitOfWork.OrdersRepository.InsertAsync(order);

        }

        [HttpPut]
        public async Task updateOne(OrderDTO orderDTO)
        {

            Order order = dtoToOrder(orderDTO);
            await _unitOfWork.OrdersRepository.SaveAsync(order);


        }

        private static OrderDTO orderToDTO(Order order) => new OrderDTO
        {
            OrderDate = order.OrderDate,
            OrderId = order.OrderId,
        };

        private static Order dtoToOrder(OrderDTO orderDTO) => new Order
        {
            OrderDate = orderDTO.OrderDate,
            OrderId = orderDTO.OrderId,
        };
    }
}
