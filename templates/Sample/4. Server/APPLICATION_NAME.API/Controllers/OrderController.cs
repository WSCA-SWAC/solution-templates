using Microsoft.AspNetCore.Mvc;
using APPLICATION_NAME.Application.Services;
using APPLICATION_NAME.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace APPLICATION_NAME.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _orderService.GetAllOrdersAsync();
            return Ok(result.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _orderService.GetOrderByIdAsync(id);
            if (result.IsFailure)
            {
                return NotFound(result.Error);
            }
            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateOrderRequest request)
        {
            var result = await _orderService.CreateOrderAsync(request.Customer);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            return Ok();
        }

        [HttpPost("{orderId}/items")]
        public async Task<IActionResult> AddItem(int orderId, [FromBody] AddOrderItemRequest request)
        {
            var result = await _orderService.AddOrderItemAsync(orderId, request.ProductId, request.ProductName, request.UnitPrice, request.Quantity);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            return Ok();
        }
    }

    public class CreateOrderRequest
    {
        public string Customer { get; set; }
    }

    public class AddOrderItemRequest
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
